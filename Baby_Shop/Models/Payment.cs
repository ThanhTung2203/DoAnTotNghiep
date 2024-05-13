
using System.ComponentModel.DataAnnotations.Schema;

namespace Baby_Shop.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime  DatePayment { get; set; }
        public string Method { get; set; }
        public int ShippingId { get; set; }
        //public int UserId { get; set; }
        public Cart? Cart { get; set; }
        public Shipping Shipping { get; set; }
        //public User User { get; set; }
    }
}
