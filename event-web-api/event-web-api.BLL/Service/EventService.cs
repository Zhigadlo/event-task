using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities;
using Entities.DatatTransferObjects;
using Entities.Exceptions;
using event_web_api.BLL.Validation;

namespace event_web_api.BLL.Service
{
    public class EventService : IEventService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private EventValidator _validator;

        public EventService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _validator = new EventValidator();
        }

        public async Task<EventDto?> CreateAsync(EventForUpdateDto eventForCreationDto, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(eventForCreationDto);
            var result = await _validator.ValidateAsync(@event, cancellationToken);
            if (!result.IsValid)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                throw new EntityIsNotValidException(message);
            }

            _repositoryManager.Event.CreateEvent(@event);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
            return _mapper.Map<EventDto>(@event);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var eventForDelete = _repositoryManager.Event.GetEvent(id, true);
            if (eventForDelete == null)
            {
                throw new NotFoundException("Event with such id is not found");
            }

            _repositoryManager.Event.DeleteEvent(eventForDelete);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<EventDto>?> GetAllAsync(bool trackChanges)
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<EventDto>>(_repositoryManager.Event.GetAllEvent(false)));
        }

        public async Task<EventDto?> GetAsync(Guid id, bool trackChanges)
        {
            return await Task.FromResult(_mapper.Map<EventDto>(_repositoryManager.Event.GetEvent(id, false)));
        }

        public async Task Update(EventForUpdateDto eventForUpdateDto, CancellationToken cancellationToken)
        {
            var @event = _repositoryManager.Event.GetEvent(eventForUpdateDto.Id, true);
            if (@event == null)
            {
                throw new NotFoundException("Event with such id is not found");
            }

            _mapper.Map(eventForUpdateDto, @event);

            var result = await _validator.ValidateAsync(@event);
            if (!result.IsValid)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                throw new EntityIsNotValidException(message);
            }

            _repositoryManager.Event.UpdateEvent(@event);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
        }
    }
}
