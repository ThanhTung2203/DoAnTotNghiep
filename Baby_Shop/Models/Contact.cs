using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Baby_Shop.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required,StringLength(200)]
        public string Message { get; set; }
        public DateTime? Create_Date { get; set; }

    }
}
