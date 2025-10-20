using DatabaseEntity.OrderItemsEntity;

namespace DTO.OrderItemDTO
{
    public class OrderedItemDTOs //Display along with CustomerOrderDetailForDisplayDTO
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal ProductSellingPrice { get; set; }
        public int OrderedQuantity { get; set; }
    }
}