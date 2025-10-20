using DatabaseEntity.CustomerEntity;
using DatabaseEntity.OrderEntity;
using DatabaseEntity.OrderItemsEntity;
using DatabaseEntity.ProductEntity;
using DatabaseEntity.ProductInventory;
using Microsoft.EntityFrameworkCore;

namespace MigrateDatabase.DatabaseContext
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customer => Set<Customer>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        public DbSet<Product> Product => Set<Product>();

        public DbSet<ProductInventory> ProductInventory => Set<ProductInventory>();
    }

}