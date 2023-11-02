using AutoMapper;
using Entities.DatatTransferObjects.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace event_web_api.BLL.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserForRegistrationDto, IdentityUser>();
        }
    }
}
