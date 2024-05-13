using System.ComponentModel.DataAnnotations;

namespace Baby_Shop.Models
{
    public class SignUpModel
    {
        [Required]
        public string Firstname { get; set; } = null!;
        [Required]
        public string Lastname { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}