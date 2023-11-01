namespace Contracts.Services
{
    public interface IServiceManager
    {
        ISpeakerService Speaker { get; }
        IEventService Event { get; }
    }
}
