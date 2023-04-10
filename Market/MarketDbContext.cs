using Market.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Market
{
    public class MarketDbContext: IdentityDbContext<Employee>

    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<ProductSaleHistory> ProductSaleHistories { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        //public DbSet<User> Users { get; set; }
        public MarketDbContext(DbContextOptions<MarketDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
