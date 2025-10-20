using System.Linq.Expressions;
using DatabaseEntity.OrderEntity;
using DatabaseEntity.OrderItemsEntity;
using DTO.CustoemrOrderDTO;
using DTO.OrderItemDTO;
using DTO.RecievedCustomerOrderDetailForDisplayDTO;
using Enum.AvailableEnum;

namespace Handler.OrderEndpoint.Mapper.CustoemrOrderMapper
{
    public class CustomerOrderMapper
    {
        public static OrderItem MapReceievedCustomerOrderDTOToOrderItem(ReceievedOrderItemDTO receievedOrderItem)
        {
            return new OrderItem
            {
                ProductID = receievedOrderItem.ProductID,
                OrderedQuantity = receievedOrderItem.OrderedQuantity,
            };
        }
        public static Order MapRecievedCustomerOrderDTOToCustomerOrder(RecievedCustomerOrderDetailDTO recievedCustomerDTO)
        {
            return new Order
            {
                CustomerID = recievedCustomerDTO.CustomerID,
                PaymentStatus = PaymentStatus.PendingPayment.ToString(),
                PaymentType = recievedCustomerDTO.PaymentType.ToString(),
                Status = OrderStatus.Pending.ToString(),
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow,
                OrderItems = recievedCustomerDTO.Item.Select(MapReceievedCustomerOrderDTOToOrderItem).ToList()
            };
        }

        public static OrderedItemDTOs MapOrderItemToOrderedItemDTOs(OrderItem orderItem)
        {
            return new OrderedItemDTOs
            {
                OrderItemID = orderItem.OrderItemID,
                OrderID = orderItem.OrderID,
                ProductID = orderItem.ProductID,
                ProductSellingPrice = orderItem.ProductSellingPrice,
                OrderedQuantity = orderItem.OrderedQuantity
            };
        }

        public static CustomerOrderDetailForDisplayDTO MapCustomerOrderToCUstomerOrderDetailsForDisplayDTO(Order order)
        {
            return new CustomerOrderDetailForDisplayDTO
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                PaymentStatus = order.PaymentStatus,
                PaymentType = order.PaymentType,
                Status = order.Status,
                TotalOrderPrice = order.TotalOrderPrice,
                CustomerOrderCreatedDate = order.CreatedDate,
                CustomerOrderLastUpdateDate = order.LastUpdatedDate,
                CustomerOrderItems = order.OrderItems.Select(MapOrderItemToOrderedItemDTOs).ToList()
            };
        }

        public static readonly Expression<Func<Order, CustomerOrderDetailForDisplayDTO>> ExpressionOrderToOrderDTO = o => new CustomerOrderDetailForDisplayDTO
        {
            OrderID = o.OrderID,
            CustomerID = o.CustomerID,
            PaymentStatus = o.PaymentStatus,
            PaymentType = o.PaymentType,
            Status = o.Status,
            CustomerOrderCreatedDate = o.CreatedDate,
            CustomerOrderLastUpdateDate = o.LastUpdatedDate,
            TotalOrderPrice = o.TotalOrderPrice,
            CustomerOrderItems = o.OrderItems.Select(item => new OrderedItemDTOs
            {
                OrderItemID = item.OrderItemID,
                OrderID = item.OrderID,
                ProductID = item.Product.ProductID,
                ProductSellingPrice = item.Product.SellingPrice,
                OrderedQuantity = item.OrderedQuantity
            }).ToList()
        };
    }
}