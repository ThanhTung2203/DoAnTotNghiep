using Baby_Shop.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        public int Id { get; set; }
        public string ShipingInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
