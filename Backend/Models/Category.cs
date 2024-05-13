using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Backend.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Tên loại ")]
        public string Name { get; set; }
        [DisplayName("Mô tả ")]
        public string Description { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Ngày cập nhật ")]
        public DateTime UpdatedAt { get; set; }
        [DisplayName("Trạng thái")]
        public byte Status { get; set; }
    }
}
