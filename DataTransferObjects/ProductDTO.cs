
namespace DTO.ProductDTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal BoughtPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string ProductGroupType { get; set; }
        public string ProductDescription { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public ProductDTO(
            int productID,
            string productName,
            decimal boughtPrice,
            decimal sellingPrice,
            string productGroupType,
            string productDescription,
            string status,
            DateTime createDate,
            DateTime lastUpdateDate
        )
        {
            ProductID = productID;
            ProductName = productName;
            BoughtPrice = boughtPrice;
            SellingPrice = sellingPrice;
            ProductGroupType = productGroupType;
            ProductDescription = productDescription;
            Status = status;
            CreatedDate = createDate;
            LastUpdatedDate = lastUpdateDate;
        }
    }

    public class RecievedProductDTO
    {
        public string ProductName { get; set; }
        public decimal BoughtPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string ProductGroupType { get; set; }
        public string ProductDescription { get; set; }
        public string Status { get; set; }

        public RecievedProductDTO(
            string productName,
            decimal boughtPrice,
            decimal sellingPrice,
            string productGroupType,
            string productDescription,
            string status
        )
        {
            ProductName = productName;
            BoughtPrice = boughtPrice;
            SellingPrice = sellingPrice;
            ProductGroupType = productGroupType;
            ProductDescription = productDescription;
            Status = status;
        }
    }
}