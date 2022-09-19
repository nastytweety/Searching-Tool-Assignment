﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Searching_Tool_Assignment.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string FullName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

}
