using System.ComponentModel.DataAnnotations;

namespace Searching_Tool_Assignment.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = String.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = String.Empty;
    }
}
