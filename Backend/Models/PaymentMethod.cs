using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PaymentMethod")]
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Ngày thanh toán")]
        public DateTime DatePayment { get; set; }
        [DisplayName("Tên phương thức thanh toán")]
        public string Method { get; set; }
        [DisplayName("Trạng thái")]
        public Boolean Status { get; set; }    
    }
}
