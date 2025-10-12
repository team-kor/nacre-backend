using DatabaseEntity.ProductEntity;
using DTO.ProductDTO;

namespace Handler.ProductEndpoint.Mapper.ProductEntityMapper
{
    public class ProductEntityMapper
    {
        public static ProductDTO MapProductToProductDTO(Product product)
        {
            return new ProductDTO(
                    product.ProductID,
                    product.ProductName,
                    product.BroughtPrice,
                    product.SellingPrice,
                    product.ProductGroupType,
                    product.ProductDescription,
                    product.Status,
                    product.CreatedDate,
                    product.LastUpdatedDate);
        }
        public static void CustomerDetailsForUpdate(RecievedProductDTO recievedProductDTO, Product product)
        {
            product.ProductName = recievedProductDTO.ProductName;
            product.BroughtPrice = recievedProductDTO.BroughtPrice;
            product.SellingPrice = recievedProductDTO.SellingPrice;
            product.ProductGroupType = recievedProductDTO.ProductGroupType;
            product.ProductDescription = recievedProductDTO.ProductDescription;
            product.Status = recievedProductDTO.Status;
            product.LastUpdatedDate = DateTime.UtcNow;
        }

        public static Product MapCustomerDTOToCustomerForInsert(RecievedProductDTO recievedProductDTO)
        {
            return new Product
            {
                ProductName = recievedProductDTO.ProductName,
                BroughtPrice = recievedProductDTO.BroughtPrice,
                SellingPrice = recievedProductDTO.SellingPrice,
                ProductGroupType = recievedProductDTO.ProductGroupType,
                ProductDescription = recievedProductDTO.ProductDescription,
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow,
            };
        }
    }
}