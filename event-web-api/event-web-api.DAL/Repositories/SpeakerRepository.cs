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

        public async Task<IQueryable<Speaker>> GetAllSpeakersAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Task.FromResult(_context.Speakers.AsNoTracking().OrderBy(s => s.FirstName));
        }

        public async Task<IQueryable<Speaker>> GetPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return (await GetAllSpeakersAsync(cancellationToken)).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public async Task<Speaker?> GetSpeakerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Speakers.AsNoTracking().SingleOrDefaultAsync(s => s.Id.Equals(id), cancellationToken);
        }

        public async Task UpdateSpeakerAsync(Speaker speaker, CancellationToken cancellationToken = default)
        {
            var speakerForUpdate = await GetSpeakerAsync(speaker.Id, cancellationToken);
            if (speakerForUpdate == null)
            {
                throw new NotFoundException("Speaker with such id is not found");
            }
            _context.Speakers.Update(speaker);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
