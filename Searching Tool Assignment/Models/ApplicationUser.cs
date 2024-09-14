using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Searching_Tool_Assignment.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string FullName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = String.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

}
