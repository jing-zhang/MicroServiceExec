using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Logging;
//using Autofac;
using System.Threading.Tasks;

namespace MicroServiceExec.RabbitMQService
{
    public interface IRMQOperator {
        void Publish(string exchange, string routingKey, string message);
        void Subscribe(string exchange, string channal, string routingKey);
    }
    public class RMQOperator : IRMQOperator
    {
        IModel channel;
        IRMQConnection _conn;
        //private readonly ILogger<RMQOperator> _logger;
        //private readonly ILifetimeScope _autofac;
        //private readonly string AUTOFAC_SCOPE_NAME = "event_bus";
        public RMQOperator(IRMQConnection connection)
        {
            _conn = connection;
            channel = _conn.connection.CreateModel();
            //_logger = logger;
        }


        public void Publish(string exchange, string routingKey, string message)
        {

            channel.ExchangeDeclare(exchange: exchange, type: "direct");

            //var message = GetMessage(args);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: exchange,
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
            //Console.WriteLine(" [x] Sent {0}", message);

            //_logger.LogTrace(" [x] Sent {0}", message);
        }

        public void Subscribe(string exchange, string channal, string routingKey)
        {
            channel.ExchangeDeclare(exchange: exchange, type: "direct");

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: channal,
                              exchange: exchange,
                              routingKey: routingKey);

            Console.WriteLine(" [*] Waiting for logs.");
            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                Console.WriteLine(" [x] {0}", Encoding.UTF8.GetString(body));
                //_logger.LogTrace(Encoding.UTF8.GetString(body));
                // insert the process
            };
            channel.BasicConsume(queue: channal,
                                 autoAck: true,
                                 consumer: consumer);
        }
       
    }
}