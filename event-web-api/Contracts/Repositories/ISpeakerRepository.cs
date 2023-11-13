using Entities;

namespace Contracts.Repositories
{
    public interface ISpeakerRepository
    {
        Task<IQueryable<Speaker>> GetAllSpeakersAsync(CancellationToken cancellationToken = default);
        Task<Speaker?> GetSpeakerAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateSpeakerAsync(Speaker speaker, CancellationToken cancellationToken = default);
        Task DeleteSpeakerAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateSpeakerAsync(Speaker speaker, CancellationToken cancellationToken = default);
    }
}
