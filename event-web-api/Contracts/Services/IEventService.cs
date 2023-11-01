using Entities.DatatTransferObjects;

namespace Contracts.Services
{
    public interface IEventService
    {
        EventDto? Create(EventForUpdateDto eventForCreationDto);
        EventDto? Delete(Guid id);
        IEnumerable<EventDto>? GetAll(bool trackChanges);
        EventDto? Get(Guid id, bool trackChanges);
        EventDto? Update(EventForUpdateDto eventForUpdateDto);
    }
}
