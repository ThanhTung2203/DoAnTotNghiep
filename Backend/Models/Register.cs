using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Repassword { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address Format")]
        public string Email { get; set; }
    }
}
