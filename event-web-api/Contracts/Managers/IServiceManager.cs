using Contracts.Services;

namespace Contracts.Managers
{
    public interface IServiceManager
    {
        ISpeakerService Speaker { get; }
        IEventService Event { get; }
    }
}
