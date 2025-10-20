using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseEntity.CustomerEntity;
using DatabaseEntity.OrderItemsEntity;

namespace DatabaseEntity.OrderEntity
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }

        [Required]
        public string PaymentStatus { get; set; } = null!;

        [Required]
        public string PaymentType { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public Customer Customer { get; set; } = null!;

        [Required]
        public List<OrderItem> OrderItems { get; set; } = new();
        
        [Required]
        public decimal TotalOrderPrice { get; set; }
    }
}