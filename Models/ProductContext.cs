using System.Data.Entity;
namespace CurryLounge.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("CurryLounge")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> ShoppingBasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}