using DatabaseEntity.CustomerEntity;
using DatabaseEntity.OrderEntity;
using DatabaseEntity.OrderItemsEntity;
using DatabaseEntity.ProductEntity;
using DatabaseEntity.ProductInventory;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MigrateDatabase.DatabaseContext
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customer => Set<Customer>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        public DbSet<Product> Product => Set<Product>();

        public DbSet<ProductInventories> ProductInventory => Set<ProductInventories>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Orders) //These are pointing back to the navigation properties
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
            .Property(p => p.BoughtPrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
            .Property(p => p.SellingPrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
            .HasOne(p => p.productInventory)
            .WithOne(pi => pi.Product)
            .HasForeignKey<ProductInventories>(p => p.ProductID)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}