using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Model
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public byte Status { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
