using System.ComponentModel.DataAnnotations;

namespace DatabaseEntity.ProductEntity
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        public double BroughtPrice { get; set; }

        [Required]
        public double SellingPrice { get; set; }

        [Required]
        public string ProductGroupType { get; set; } = null!;

        [Required]
        public string ProductDescription { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }
    }
}