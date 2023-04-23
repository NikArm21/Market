using Market.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Market
{
    public class MarketDbContext : IdentityDbContext<Employee>

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
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleId = Guid.NewGuid().ToString();
            string adminId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "admin",
                NormalizedName = "admin"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "manager",
                NormalizedName = "manager"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "kassa",
                NormalizedName = "kassa"
            });

            var hasher = new PasswordHasher<Employee>();
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
                SecurityStamp = string.Empty,
                FullName="admin"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId,
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
