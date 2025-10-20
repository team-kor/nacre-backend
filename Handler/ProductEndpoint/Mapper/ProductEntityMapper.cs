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
                    product.BoughtPrice,
                    product.SellingPrice,
                    product.ProductGroupType,
                    product.ProductDescription,
                    product.Status,
                    product.CreatedDate,
                    product.LastUpdatedDate);
        }
        public static void ProductDetailsForUpdate(RecievedProductDTO recievedProductDTO, Product product)
        {
            product.ProductName = recievedProductDTO.ProductName;
            product.BoughtPrice = recievedProductDTO.BoughtPrice;
            product.SellingPrice = recievedProductDTO.SellingPrice;
            product.ProductGroupType = recievedProductDTO.ProductGroupType;
            product.ProductDescription = recievedProductDTO.ProductDescription;
            product.Status = recievedProductDTO.Status;
            product.LastUpdatedDate = DateTime.UtcNow;
        }

        public static Product MapProductDTOToCustomerForInsert(RecievedProductDTO recievedProductDTO)
        {
            return new Product
            {
                ProductName = recievedProductDTO.ProductName,
                BoughtPrice = recievedProductDTO.BoughtPrice,
                SellingPrice = recievedProductDTO.SellingPrice,
                ProductGroupType = recievedProductDTO.ProductGroupType,
                ProductDescription = recievedProductDTO.ProductDescription,
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow,
            };
        }
    }
}