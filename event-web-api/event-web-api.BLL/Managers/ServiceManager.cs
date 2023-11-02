using AutoMapper;
using Contracts.Managers;
using Contracts.Services;
using event_web_api.BLL.Service;

namespace event_web_api.BLL.Managers
{
    public class ServiceManager : IServiceManager
    {
        private ISpeakerService? _speaker;
        private IEventService? _event;

        private IMapper _mapper;
        private IRepositoryManager _repositoryManager;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public ISpeakerService Speaker
        {
            get
            {
                if (_speaker == null)
                    _speaker = new SpeakerService(_repositoryManager, _mapper);

                return _speaker;
            }
        }

        public IEventService Event
        {
            get
            {
                if (_event == null)
                    _event = new EventService(_repositoryManager, _mapper);

                return _event;
            }
        }

    }
}
