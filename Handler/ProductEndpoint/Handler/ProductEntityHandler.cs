
using System.Runtime.Serialization;
using DatabaseEntity.ProductEntity;
using DTO.ProductDTO;
using Handler.ProductEndpoint.IProductHandler;
using Handler.ProductEndpoint.Mapper.ProductEntityMapper;
using Microsoft.EntityFrameworkCore;
using MigrateDatabase.DatabaseContext;

namespace Handler.ProductEndpoint.ProductHandler
{
    public class ProductHandlers : IProductHandlers
    {
        public readonly DatabaseContext _database;

        public ProductHandlers(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<List<ProductDTO>> GetAllProductDetails(CancellationToken cancellationToken)
        {
            List<Product> allAvailableProduct = await _database.Product.AsNoTracking().ToListAsync(cancellationToken);
            return allAvailableProduct.Select(ProductEntityMapper.MapProductToProductDTO).ToList();
        }

        public async Task<ProductDTO?> GetProductByID(int id, CancellationToken cancellationToken)
        {
            Product productById = await _database.Product.FirstOrDefaultAsync(productById => productById.ProductID == id);
            if (productById == null)
            {
                return null;
            }
            return ProductEntityMapper.MapProductToProductDTO(productById);
        }

        public async Task<ProductDTO?> UpdateProductDetailsByID(int id, RecievedProductDTO recievedProductDTO, CancellationToken cancellationToken)
        {
            Product existingProduct = await _database.Product.FindAsync(id, cancellationToken);
            if (existingProduct == null)
            {
                return null;
            }
            ProductEntityMapper.ProductDetailsForUpdate(recievedProductDTO, existingProduct);

            await _database.SaveChangesAsync(cancellationToken);

            return ProductEntityMapper.MapProductToProductDTO(existingProduct);
        }

        public async Task<ProductDTO?> InsertNewProductDetails(RecievedProductDTO recievedProductDTO, CancellationToken cancellationToken)
        {
            Product createdProduct = ProductEntityMapper.MapProductDTOToCustomerForInsert(recievedProductDTO);
            await _database.Product.AddAsync(createdProduct, cancellationToken);
            await _database.SaveChangesAsync(cancellationToken);

            return ProductEntityMapper.MapProductToProductDTO(createdProduct);
        }

        public async Task<bool> DeleteProductDetails(int id, CancellationToken cancellationToken)
        {
            Product existingProduct = await _database.Product.FindAsync(id, cancellationToken);
            if (existingProduct == null)
            {
                return false;
            }
            _database.Product.Remove(existingProduct);
            await _database.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}