using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Model
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public Boolean Status { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public Product? Product { get; set; }
        public User? User { get; set; }
       
    }
}
