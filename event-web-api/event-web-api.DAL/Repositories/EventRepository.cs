using Contracts.Repositories;
using Entities;
using event_web_api.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace event_web_api.DAL.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(EventContext context) : base(context)
        {
        }

        public void CreateEvent(Event @event) => Create(@event);

        public void DeleteEvent(Event @event) => Delete(@event);

        public IQueryable<Event> GetAllEventAsync(bool trackChanges) => FindAll(trackChanges).Include(e => e.Speaker).OrderBy(e => e.Date);

        public Event? GetEventAsync(int id, bool trackChanges) => FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateEvent(Event @event) => Update(@event);
    }
}
