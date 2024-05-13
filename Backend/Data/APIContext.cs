using Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class APIContext : IdentityDbContext<User>
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rating>  Ratings { get; set; }
        public DbSet<Voucher>  Vouchers { get; set; }
        public DbSet<Favourite>  Favourites { get; set; }
        public DbSet<ProductVoucher>  ProductVouchers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
