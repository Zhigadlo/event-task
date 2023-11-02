using Entities;

namespace Contracts.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges, CancellationToken cancellationToken = default);
        Task<Event?> GetEventAsync(Guid id, bool trackChanges, CancellationToken cancellationToken = default);
        Task CreateEventAsync(Event @event, CancellationToken cancellationToken = default);
        Task DeleteEventAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateEventAsync(Event @event, CancellationToken cancellationToken = default);
    }
}
