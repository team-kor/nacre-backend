using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseEntity.OrderEntity;
using DatabaseEntity.ProductEntity;

namespace DatabaseEntity.OrderItemsEntity
{
    public class OrderItems
    {
        [Key]
        public int Order_Item { get; set; }
        
        [ForeignKey(nameof(Orders))]
        public int OrderID { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public Orders Order { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }

        [Required]
        public Product Product { get; set; } = null!;
    }
}