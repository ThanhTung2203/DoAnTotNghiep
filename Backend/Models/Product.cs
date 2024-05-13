using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Backend.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        [DisplayName("Hàng tồn kho")]
        public int Stock { get; set; }
        [Required]
        [DisplayName("Giá tiền")]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        [DisplayName("Hình Ảnh")]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Trạng thái")]
        public Boolean Status { get; set; }
        //public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
