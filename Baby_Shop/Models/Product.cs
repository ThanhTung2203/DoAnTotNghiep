using Baby_Shop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int Stock { get; set; }
        [Required]
        [StringLength(50)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(50)]
        public int Quantity { get; set; }
        public string? Image { get; set; }
        //[NotMapped]
        //public IFormFile? ImageFile { get; set; } = null;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public Boolean Status { get; set; }

       
        //public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
