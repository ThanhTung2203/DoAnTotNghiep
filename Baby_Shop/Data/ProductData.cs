using Baby_Shop.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Data
{
    public class ProductData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public Category Category { get; set; }
        public Boolean Status { get; set; }
    }
}
