using System.ComponentModel.DataAnnotations;

namespace Entities.DatatTransferObjects.UserDtos
{
    public class UserForRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
