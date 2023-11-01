using Entities.DatatTransferObjects;

namespace Contracts.Services
{
    public interface IEventService
    {
        Task<EventDto?> CreateAsync(EventForUpdateDto eventForCreationDto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<EventDto>?> GetAllAsync(bool trackChanges);
        Task<EventDto?> GetAsync(Guid id, bool trackChanges);
        Task Update(EventForUpdateDto eventForUpdateDto, CancellationToken cancellationToken);
    }
}
