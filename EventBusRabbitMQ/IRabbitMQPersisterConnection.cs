using System;
using RabbitMQ.Client;

namespace MicroServiceExec.EventBusRabbitMQ
{
    public interface IRabbitMQPersistentConnection  : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
