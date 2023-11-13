using Contracts.Services;
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
        private ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetSpeakersAsync(CancellationToken cancellationToken = default)
        {
            var speakers = await _speakerService.GetAllAsync(false, cancellationToken);
            return Ok(speakers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> GetSpeakerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var speaker = await _speakerService.GetAsync(id, false, cancellationToken);
            return Ok(speaker);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> CreateSpeakerAsync([FromBody] SpeakerForCreationDto speakerForCreation, CancellationToken cancellationToken = default)
        {
            var createdSpeaker = await _speakerService.CreateAsync(speakerForCreation, cancellationToken);
            return Ok(createdSpeaker);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> UpdateSpeakerAsync([FromBody] SpeakerDto speakerForUpdate, CancellationToken cancellationToken = default)
        {
            await _speakerService.UpdateAsync(speakerForUpdate, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public async Task<IActionResult> DeleteSpeakerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _speakerService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
