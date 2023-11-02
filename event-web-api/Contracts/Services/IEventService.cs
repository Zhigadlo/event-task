using Entities.DatatTransferObjects;

namespace Contracts.Services
{
    public interface IEventService
    {
        Task<EventDto?> CreateAsync(EventForCreationDto eventForCreationDto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<EventDto>?> GetAllAsync(bool trackChanges, CancellationToken cancellationToken);
        Task<EventDto?> GetAsync(Guid id, bool trackChanges, CancellationToken cancellationToken);
        Task UpdateAsync(EventForUpdateDto eventForUpdateDto, CancellationToken cancellationToken);
    }
}
