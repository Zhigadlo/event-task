using Entities.DatatTransferObjects.UserDtos;

namespace Contracts.Managers
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
