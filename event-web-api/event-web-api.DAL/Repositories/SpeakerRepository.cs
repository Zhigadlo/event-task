using Contracts.Repositories;
using Entities;
using Entities.Exceptions;
using event_web_api.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace event_web_api.DAL.Repositories
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private EventContext _context;
        public SpeakerRepository(EventContext context)
        {
            _context = context;
        }

        public async Task CreateSpeakerAsync(Speaker speaker, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(speaker, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteSpeakerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var speakerForDelete = await _context.Speakers.SingleOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
            if (speakerForDelete == null)
            {
                throw new NotFoundException("Speaker with such id not found");
            }
            _context.Remove(speakerForDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool trackChanges, CancellationToken cancellationToken = default)
        {
            return await (trackChanges ? _context.Speakers.AsNoTracking() : _context.Speakers).OrderBy(s => s.FirstName).ToListAsync(cancellationToken);
        }

        public async Task<Speaker?> GetSpeakerAsync(Guid id, bool trackChanges, CancellationToken cancellationToken = default)
        {
            return await (trackChanges ? _context.Speakers.AsNoTracking() : _context.Speakers).SingleOrDefaultAsync(s => s.Id.Equals(id), cancellationToken);
        }

        public async Task UpdateSpeakerAsync(Speaker speaker, CancellationToken cancellationToken = default)
        {
            var speakerForUpdate = await GetSpeakerAsync(speaker.Id, true, cancellationToken);
            if (speakerForUpdate == null)
            {
                throw new NotFoundException("Speaker with such id is not found");
            }
            _context.Speakers.Update(speaker);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
