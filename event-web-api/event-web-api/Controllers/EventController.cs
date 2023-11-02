using Contracts.Managers;
using Entities.DatatTransferObjects.EventDtos;
using Entities.ErrorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace event_web_api.Controllers
{
    [ApiController]
    [Route("api/events")]
    [Authorize]
    public class EventController : Controller
    {
        private IServiceManager _serviceManager;

        public EventController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetEventsAsync(CancellationToken cancellationToken = default)
        {
            var events = await _serviceManager.Event.GetAllAsync(false, cancellationToken);
            return Ok(events);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetEventAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var @event = await _serviceManager.Event.GetAsync(id, false, cancellationToken);
            return Ok(@event);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> CreateEventAsync([FromBody] EventForCreationDto eventForCreation, CancellationToken cancellationToken = default)
        {
            var createdEvent = await _serviceManager.Event.CreateAsync(eventForCreation, cancellationToken);
            return Ok(createdEvent);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> UpdateEventAsync([FromBody] EventForUpdateDto eventForUpdate, CancellationToken cancellationToken = default)
        {
            await _serviceManager.Event.UpdateAsync(eventForUpdate, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> DeleteEventAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _serviceManager.Event.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
