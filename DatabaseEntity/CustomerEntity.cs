using System.ComponentModel.DataAnnotations;

namespace DatabaseEntity.CustomerEntity
{
    public class Customer
    {   
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string ContactPreference { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;
    }
}