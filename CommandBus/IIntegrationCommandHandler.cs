using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceExec.CommandBus
{
    public interface IIntegrationCommandHandler
    {
        void Handle(IntegrationCommand command);
    }

    public interface IIntegrationCommandHandler<T> : IIntegrationCommandHandler
    {
        void Hander(IntegrationCommand<T> command);
    }
}
