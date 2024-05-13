using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Model
{
    [Table("Shipping")]
    public class Shipping
    {
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public decimal PriceShip { get; set; }
    }
}
