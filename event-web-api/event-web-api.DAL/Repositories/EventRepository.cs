using Contracts.Repositories;
using Entities;
using Entities.Exceptions;
using event_web_api.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace event_web_api.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private EventContext _context;
        public EventRepository(EventContext context)
        {
            _context = context;
        }

        public async Task CreateEventAsync(Event @event, CancellationToken cancellationToken = default)
        {
            @event.Speaker = await _context.Speakers.SingleOrDefaultAsync(s => s.Id.Equals(@event.SpeakerId), cancellationToken);
            if (@event.Speaker == null)
            {
                throw new NotFoundException("Speaker for event with such id is not found");
            }
            await _context.Events.AddAsync(@event, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteEventAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var eventForDelete = await _context.Events.SingleOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
            if (eventForDelete == null)
            {
                throw new NotFoundException("Event with such id is not found");
            }
            _context.Remove(eventForDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges, CancellationToken cancellationToken = default)
        {
            return await (trackChanges ? _context.Events.AsNoTracking() : _context.Events).Include(e => e.Speaker).OrderBy(e => e.Date).ToListAsync(cancellationToken);
        }

        public async Task<Event?> GetEventAsync(Guid id, bool trackChanges, CancellationToken cancellationToken = default)
        {
            return await (trackChanges ? _context.Events.AsNoTracking() : _context.Events).Include(e => e.Speaker).SingleOrDefaultAsync(e => e.Id.Equals(id), cancellationToken); ;
        }

        public async Task UpdateEventAsync(Event @event, CancellationToken cancellationToken = default)
        {
            _context.Events.Update(@event);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
