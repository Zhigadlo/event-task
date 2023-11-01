using Entities;

namespace Contracts.Repositories
{
    public interface IEventRepository
    {
        IQueryable<Event> GetAllEvent(bool trackChanges);
        Event? GetEvent(Guid id, bool trackChanges);
        void CreateEvent(Event @event);
        void DeleteEvent(Event @event);
        void UpdateEvent(Event @event);
    }
}
