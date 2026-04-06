using ECommerceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // ✅ Static pre-hashed password for "Admin@123"
            // Generated once using BCrypt.HashPassword("Admin@123")
            const string adminPasswordHash =
    "$2a$11$lPovzVAQQ/XX2518Q8vtoub14F/l0hnRorlvZnRP00THk7Imh.TiK";
            modelBuilder.Entity<User>().HasData(new User
            {
                Id           = 1,
                Name         = "Admin User",
                Email        = "admin@ecommerce.com",
                PasswordHash = adminPasswordHash,
                Role         = "Admin"
            });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing"    },
                new Category { Id = 3, Name = "Books"       }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop",         Description = "High-performance laptop", Price = 999.99m, Stock = 10 },
                new Product { Id = 2, Name = "T-Shirt",        Description = "Cotton T-Shirt",          Price = 19.99m,  Stock = 50 },
                new Product { Id = 3, Name = "C# Programming", Description = "Learn C# from scratch",   Price = 29.99m,  Stock = 30 }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 2 },
                new ProductCategory { ProductId = 3, CategoryId = 3 }
            );
        }
    }
}