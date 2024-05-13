using Baby_Shop.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string DeliverAddress { get; set; }
        public string DeliverPhone { get; set; }
        public string DeliverUser { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime? Created_Date { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
