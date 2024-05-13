using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Model
{
    [Table("User")]
    public class User:IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; }= null!;

    }
}
