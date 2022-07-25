using System.ComponentModel.DataAnnotations;

namespace IdentityVote.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

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
        public string Phone { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public string? Address { get; set; }
        public string? Postode { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Profession { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? YearOfBirth { get; set; }
        public bool? HasVoted { get; set; }
        public bool? PaidSubscription { get; set; }
        public string? About { get; set; }
        public byte[]? Image { get; set; }
    }
}
