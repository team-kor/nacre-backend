using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseEntity.ProductEntity;
using Microsoft.AspNetCore.Components.Forms;

namespace DatabaseEntity.ProductInventory
{
    public class ProductInventories
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }

        [Required]
        public int ReserveQuantity { get; set; }
        
        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public Product Product { get; set; } = null!;
    }
}