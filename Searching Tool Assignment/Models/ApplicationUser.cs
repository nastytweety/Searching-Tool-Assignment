using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searching_Tool_Assignment.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }
        public string FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

}
