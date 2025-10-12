
namespace DTO.ProductDTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double BroughtPrice { get; set; }
        public double SellingPrice { get; set; }
        public string ProductGroupType { get; set; }
        public string ProductDescription { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public ProductDTO(
            int productID,
            string productName,
            double broughtPrice,
            double sellingPrice,
            string productGroupType,
            string productDescription,
            string status,
            DateTime createDate,
            DateTime lastUpdateDate
        )
        {
            ProductID = productID;
            ProductName = productName;
            BroughtPrice = broughtPrice;
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
        public double BroughtPrice { get; set; }
        public double SellingPrice { get; set; }
        public string ProductGroupType { get; set; }
        public string ProductDescription { get; set; }
        public string Status { get; set; }

        public RecievedProductDTO(
            string productName,
            double broughtPrice,
            double sellingPrice,
            string productGroupType,
            string productDescription,
            string status
        )
        {
            ProductName = productName;
            BroughtPrice = broughtPrice;
            SellingPrice = sellingPrice;
            ProductGroupType = productGroupType;
            ProductDescription = productDescription;
            Status = status;
        }
    }
}