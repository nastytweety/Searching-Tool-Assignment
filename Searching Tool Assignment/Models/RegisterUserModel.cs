using System.ComponentModel.DataAnnotations;

namespace Searching_Tool_Assignment.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string FullName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
