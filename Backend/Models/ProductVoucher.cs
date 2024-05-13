using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ProductVoucher")]
    public class ProductVoucher
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int VoucherId { get; set; }
        public Product Product { get; set; }
        public Voucher Voucher { get; set; }
    }
}
