using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext()
        {
        }
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Food"));
            }

            optionsBuilder.EnableSensitiveDataLogging(); // Optional: chỉ sử dụng trong môi trường phát triển
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tùy chỉnh các cấu hình khác (nếu cần)
            base.OnModelCreating(modelBuilder);
        }
    }
}
