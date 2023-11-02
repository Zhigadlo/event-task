using Contracts.Managers;
using Entities.DatatTransferObjects.SpeakerDtos;
using Entities.ErrorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace event_web_api.Controllers
{
    [ApiController]
    [Route("api/speakers")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SpeakerController : Controller
    {
        private IServiceManager _serviceManager;

        public SpeakerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetSpeakersAsync(CancellationToken cancellationToken = default)
        {
            var speakers = await _serviceManager.Speaker.GetAllAsync(false, cancellationToken);
            return Ok(speakers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetSpeakerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var speaker = await _serviceManager.Speaker.GetAsync(id, false, cancellationToken);
            return Ok(speaker);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> CreateSpeakerAsync([FromBody] SpeakerForCreationDto speakerForCreation, CancellationToken cancellationToken = default)
        {
            var createdSpeaker = await _serviceManager.Speaker.CreateAsync(speakerForCreation, cancellationToken);
            return Ok(createdSpeaker);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> UpdateSpeakerAsync([FromBody] SpeakerDto speakerForUpdate, CancellationToken cancellationToken = default)
        {
            await _serviceManager.Speaker.UpdateAsync(speakerForUpdate, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> DeleteSpeakerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _serviceManager.Speaker.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
