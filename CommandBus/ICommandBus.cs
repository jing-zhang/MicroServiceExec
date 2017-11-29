using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceExec.CommandBus
{
    public interface ICommandBus
    {
        //Task SendAync<T>(T command) 
        //    //where T : IntergrationCommand
        //    ;
        void Send<T>(string name, T data);
        void Handle<TC>(string name, IIntegrationCommandHandler<TC> handler);
        void Handle(string name, IIntegrationCommandHandler handler);
        void Handle<TI, TC>(TI handle) where TI: IIntegrationCommandHandler<TC>;
    }
}
