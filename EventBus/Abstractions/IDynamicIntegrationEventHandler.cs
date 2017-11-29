using System.Threading.Tasks;

namespace MicroServiceExec.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
