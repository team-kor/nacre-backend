using DTO.OrderItemDTO;
using Enum.AvailableEnum;

namespace DTO.RecievedCustomerOrderDetailForDisplayDTO
{
    public class RecievedCustomerOrderDetailDTO
    {
        public int CustomerID { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<ReceievedOrderItemDTO> Item { get; set; }
    }

    public class ReceievedOrderItemDTO
    {
        public int ProductID { get; set; }
        public int OrderedQuantity { get; set; }
        public decimal ProductSellingPrice { get; set; }

    }
}