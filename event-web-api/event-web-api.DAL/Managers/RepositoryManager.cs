using Contracts.Repositories;
using event_web_api.DAL.EF;
using event_web_api.DAL.Repositories;

namespace event_web_api.DAL.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private ISpeakerRepository _speaker;
        private IEventRepository _event;

        private EventContext _context;
        public RepositoryManager(EventContext context)
        {
            _context = context;
        }
        public ISpeakerRepository Speaker
        {
            get
            {
                if (_speaker == null)
                    _speaker = new SpeakerRepository(_context);

                return _speaker;
            }
        }

        public IEventRepository Event
        {
            get
            {
                if (_event == null)
                    _event = new EventRepository(_context);

                return _event;
            }
        }
    }
}
