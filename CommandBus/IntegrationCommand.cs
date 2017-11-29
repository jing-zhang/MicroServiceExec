using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceExec.CommandBus
{
    public abstract class IntegrationCommand
    {
        public Guid Id { get; private set; }
        public DateTime Send { get; private set; }

        public abstract object GetDataAsObject();

        protected IntegrationCommand()
        {
            Id = Guid.NewGuid();
            Send = DateTime.UtcNow;
        }
    }

    public class IntegrationCommand<T> : IntegrationCommand
    {
        public T Data { get; }
        public string Name { get; }
        public override object GetDataAsObject() => Data;
        public IntegrationCommand(string name, T data) : base()
        {
            Data = data;
            Name = name;
        }
    }
}
