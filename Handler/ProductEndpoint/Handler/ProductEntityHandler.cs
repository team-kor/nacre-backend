
using DatabaseEntity.ProductEntity;
using Microsoft.EntityFrameworkCore;
using MigrateDatabase.DatabaseContext;

namespace Handler.ProductEndpoint.ProductHandler
{
    public class ProductHandlers
    {
        public readonly DatabaseContext _database;

        public ProductHandlers(DatabaseContext database)
        {
            _database = database;
        }

        // public async Task<List<Product>> GetAllAvailableProduct(CancellationToken cancellationToken = default)
        // {
        //     List<Product> allAvailableProduct = await _database.Product.AsNoTracking().ToListAsync(cancellationToken);
        //     return all
        // }
    }
}