using Entities.DatatTransferObjects.EventDtos;

namespace Contracts.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<EventDto?> CreateAsync(EventForCreationDto eventForCreationDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<EventDto>?> GetAllAsync(CancellationToken cancellationToken = default);
        Task<EventDto?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(EventForUpdateDto eventForUpdateDto, CancellationToken cancellationToken = default);
    }
}
