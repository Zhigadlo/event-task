using Contracts.Services;
using Entities.DatatTransferObjects.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace event_web_api.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _authenticationService.RegisterUser(userForRegistration);
            return result.Succeeded ? StatusCode(201) : BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            var token = await _authenticationService.AuthenticateUser(user);
            return token == null ? Unauthorized() : Ok(token);
        }
    }
}
