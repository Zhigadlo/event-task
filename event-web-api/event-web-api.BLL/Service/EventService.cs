﻿using AutoMapper;
using Contracts.Managers;
using Contracts.Services;
using Entities;
using Entities.DatatTransferObjects.EventDtos;
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

        public async Task<EventDto?> CreateAsync(EventForCreationDto eventForCreationDto, CancellationToken cancellationToken = default)
        {
            var @event = _mapper.Map<Event>(eventForCreationDto);
            var result = await _validator.ValidateAsync(@event, cancellationToken);
            if (!result.IsValid)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                throw new EntityIsNotValidException(message);
            }

            await _repositoryManager.Event.CreateEventAsync(@event, cancellationToken);
            return _mapper.Map<EventDto>(@event);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _repositoryManager.Event.DeleteEventAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<EventDto>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<EventDto>>(await _repositoryManager.Event.GetAllEventsAsync(cancellationToken));
        }

        public async Task<EventDto?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<EventDto>(await _repositoryManager.Event.GetEventAsync(id, cancellationToken));
        }

        public async Task<IEnumerable<EventDto>> GetPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<EventDto>>(await _repositoryManager.Event.GetPageAsync(pageNumber, pageSize, cancellationToken));
        }

        public async Task UpdateAsync(EventForUpdateDto eventForUpdateDto, CancellationToken cancellationToken = default)
        {
            var @event = _mapper.Map<Event>(eventForUpdateDto);

            var result = await _validator.ValidateAsync(@event, cancellationToken);
            if (!result.IsValid)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));
                throw new EntityIsNotValidException(message);
            }

            await _repositoryManager.Event.UpdateEventAsync(@event, cancellationToken);
        }
    }
}
