using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Backend.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        [DisplayName("Giá tiền ")]
        public decimal Price { get; set; }
        [DisplayName("Tổng tiền")]
        public decimal TotalPice { get; set; }
        [DisplayName("Ngày tạo giỏ hàng")]
        public DateTime CreateDate { get; set; } 
        public Boolean Status { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
