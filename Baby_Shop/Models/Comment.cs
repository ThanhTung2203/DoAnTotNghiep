using Baby_Shop.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Models
{
    [Table("Comment")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CommentDate { get; set; }
        public Boolean Status { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
