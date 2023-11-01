using Entities;

namespace Contracts.Repositories
{
    public interface ISpeakerRepository
    {
        IQueryable<Speaker> GetAllSpeaker(bool trackChanges);
        Speaker? GetSpeaker(Guid id, bool trackChanges);
        void CreateSpeaker(Speaker speaker);
        void DeleteSpeaker(Speaker speaker);
        void UpdateSpeaker(Speaker speaker);
    }
}
