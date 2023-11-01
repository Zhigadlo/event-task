using Entities.DatatTransferObjects;

namespace Contracts.Services
{
    public interface ISpeakerService
    {
        SpeakerDto? Create(SpeakerForCreationDto speakerForCreationDto);
        SpeakerDto? Delete(Guid id);
        IEnumerable<SpeakerDto>? GetAll(bool trackChanges);
        SpeakerDto? Get(Guid id, bool trackChanges);
        SpeakerDto? Update(SpeakerDto speakerForUpdateDto);
    }
}
