using Baby_Shop.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Models
{
    [Table("ImageProduct")]
    public class ImageProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public Product?  Product { get; set; }
    }
}
