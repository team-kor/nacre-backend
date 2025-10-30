using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseEntity.OrderEntity;
using DatabaseEntity.ProductEntity;

namespace DatabaseEntity.OrderItemsEntity
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        
        [ForeignKey(nameof(Orders))]
        public int OrderID { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

        public decimal ProductSellingPrice { get; set; }

        [Required]
        public int OrderedQuantity { get; set; }
        
        [Required]
        public decimal TotalOrderPriceForItem { get; set; }

        [Required]
        public Order Orders { get; set; }

        [Required]
        public Product Product { get; set; } = null!;
    }
}