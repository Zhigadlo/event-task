using Contracts.Repositories;
using Entities;
using event_web_api.DAL.EF;

namespace event_web_api.DAL.Repositories
{
    public class SpeakerRepository : RepositoryBase<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(EventContext context) : base(context)
        {
        }

        public void CreateSpeaker(Speaker speaker) => Create(speaker);

        public void DeleteSpeaker(Speaker speaker) => Delete(speaker);

        public IQueryable<Speaker> GetAllSpeaker(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.FirstName);

        public Speaker? GetSpeaker(Guid id, bool trackChanges) => FindByCondition(s => s.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateSpeaker(Speaker speaker) => Update(speaker);
    }
}
