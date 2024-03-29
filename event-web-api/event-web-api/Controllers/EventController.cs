﻿using Contracts.Services;
using Entities.DatatTransferObjects.EventDtos;
using Entities.ErrorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace event_web_api.Controllers
{
    [ApiController]
    [Route("api/events")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EventController : Controller
    {
        private IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetEventsAsync(CancellationToken cancellationToken = default)
        {
            var events = await _eventService.GetAllAsync(cancellationToken);
            return Ok(events);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetEventAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var @event = await _eventService.GetAsync(id, cancellationToken);
            return Ok(@event);
        }

        [HttpGet("{pageNumber}&{pageSize}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetPageAsync(int pageNumber = 1, int pageSize = 15, CancellationToken cancellationToken = default)
        {
            var eventPage = await _eventService.GetPageAsync(pageNumber, pageSize, cancellationToken);
            return Ok(eventPage);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> CreateEventAsync([FromBody] EventForCreationDto eventForCreation, CancellationToken cancellationToken = default)
        {
            var createdEvent = await _eventService.CreateAsync(eventForCreation, cancellationToken);
            return Ok(createdEvent);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> UpdateEventAsync([FromBody] EventForUpdateDto eventForUpdate, CancellationToken cancellationToken = default)
        {
            await _eventService.UpdateAsync(eventForUpdate, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> DeleteEventAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _eventService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
