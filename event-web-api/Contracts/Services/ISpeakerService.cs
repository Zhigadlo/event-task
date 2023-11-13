using Entities.DatatTransferObjects.SpeakerDtos;

namespace Contracts.Services
{
    public interface ISpeakerService
    {
        Task<SpeakerDto?> CreateAsync(SpeakerForCreationDto speakerForCreationDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<SpeakerDto>?> GetAllAsync(CancellationToken cancellationToken = default);
        Task<SpeakerDto?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(SpeakerDto speakerForUpdateDto, CancellationToken cancellationToken = default);
    }
}
