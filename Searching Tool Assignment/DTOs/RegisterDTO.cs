using System.ComponentModel.DataAnnotations;

namespace Searching_Tool_Assignment.DTOs
{
    public record RegisterDTO
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string FullName { get; set; } = String.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = String.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = String.Empty;
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = String.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
