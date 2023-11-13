using Entities.Authentication;
using Entities.DatatTransferObjects.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<JwtToken?> AuthenticateUser(UserForAuthenticationDto userForAuthentication);
    }
}
