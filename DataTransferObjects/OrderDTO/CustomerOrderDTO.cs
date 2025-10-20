
using DatabaseEntity.OrderItemsEntity;
using DTO.OrderItemDTO;

namespace DTO.CustoemrOrderDTO
{
    public class CustomerOrderDetailForDisplayDTO //Used to display order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string PaymentStatus { get; set; } = null!;
        public string PaymentType { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal TotalOrderPrice { get; set; }
        public DateTime CustomerOrderCreatedDate { get; set; }
        public DateTime CustomerOrderLastUpdateDate { get; set; }
        public List<OrderedItemDTOs> CustomerOrderItems { get; set; }
    }
}