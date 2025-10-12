using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseEntity.ProductEntity;
using Microsoft.AspNetCore.Components.Forms;

namespace DatabaseEntity.ProductInventory
{
    public class ProductInventory
    {
        [Key]
        public int PIID { get; set; }
        
        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }

        [Required]
        public int ReserveQuantity { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }

        [Required]
        public Product Product { get; set; } = null!;
    }
}