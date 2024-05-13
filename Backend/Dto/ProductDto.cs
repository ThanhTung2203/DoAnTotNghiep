using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Backend.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string fileImage { get; set; }
        public Boolean Status { get; set; }

    }
}
