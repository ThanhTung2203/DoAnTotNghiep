using Baby_Shop.Model;
using Baby_Shop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Baby_Shop.Data
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ProductData>Products { get; set; }
        public DbSet<Cart>  Carts { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Invoice> Invoices  { get; set; }
        public DbSet<InvoiceDetail>  InvoiceDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<ImageProduct> ImageProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}

