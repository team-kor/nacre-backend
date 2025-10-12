using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseEntity.CustomerEntity;

namespace DatabaseEntity.OrderEntity
{
    public class Orders
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

        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }

        [Required]
        public Customer Customer { get; set; } = null!; 
    }
}