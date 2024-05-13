using Baby_Shop.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Models
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public Invoice? Invoice { get; set; }
        public Product?  Product { get; set; }
    }
}
