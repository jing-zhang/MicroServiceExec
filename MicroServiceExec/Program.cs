using System;

using MicroServiceExec.RabbitMQService;
using Autofac;

namespace MicroServiceExec
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            IocInit();
            Receive();
        }

        private static void IocInit()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RMQConnection>().As<IRMQConnection>();
            builder.RegisterType<RMQOperator>().As<IRMQOperator>();

            Container = builder.Build();

        }

        private static void Send()
        {
            using(var scope = Container.BeginLifetimeScope())
            {
                var _event = scope.Resolve<IRMQOperator>();

                _event.Publish("my_exchange", "my_key", "Hi Buddy");

            }
        }


        private static void Receive()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var _event = scope.Resolve<IRMQOperator>();

                _event.Subscribe("my_exchange", "my_queue", "my_key");

            }
        }
    }
}
