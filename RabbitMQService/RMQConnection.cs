using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;


namespace MicroServiceExec.RabbitMQService
{
    public interface IRMQConnection {
        IConnection connection { get;}
    }

    public class RMQConnection : IRMQConnection
    {
        public IConnection connection { get; private set; }

        public RMQConnection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            connection = factory.CreateConnection();
        }

        public RMQConnection(string username, string password, string vHost, string host)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = username;
            factory.Password = password;
            factory.VirtualHost = vHost;
            factory.HostName = host;
            connection = factory.CreateConnection();
        }

        public RMQConnection(Uri uri)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = uri;
            connection = factory.CreateConnection();
        }
    }
}
