using DTO.ProductDTO;
using Handler.ProductEndpoint.ProductHandler;

namespace Handler.ProductEndpoint.IProductHandler
{
    public interface IProductHandlers
    {
        public Task<List<ProductDTO>> GetAllProductDetails(CancellationToken cancellationToken);
        public Task<ProductDTO?> GetProductByID(int id, CancellationToken cancellationToken);
        public Task<ProductDTO?> UpdateProductDetailsByID(int id,RecievedProductDTO recievedProductDTO, CancellationToken cancellationToken);
        public Task<ProductDTO?> InsertNewProductDetails(RecievedProductDTO recievedProductDTO, CancellationToken cancellationToken);
        public Task<bool> DeleteProductDetails(int id, CancellationToken cancellationToken);
    }
}