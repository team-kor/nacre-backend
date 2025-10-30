using System.ComponentModel.DataAnnotations;
using DatabaseEntity.ProductInventory;

namespace DatabaseEntity.ProductEntity
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        public decimal BoughtPrice { get; set; }

        [Required]
        public decimal SellingPrice { get; set; }

        [Required]
        public string ProductGroupType { get; set; } = null!;

        [Required]
        public string ProductDescription { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;
        
        public ProductInventories productInventory { get; set; }
    }
}