using DTO.CustoemrOrderDTO;
using Enum.AvailableEnum;

namespace Handler.OrderEndpoint.IPutCustomerOrderHandler
{
    public interface IPutCustomerOrderHandlers
    {
        public Task<CustomerOrderDetailForDisplayDTO> UpdateOrderStatus(int orderId, OrderStatus orderStatus, CancellationToken cancellationToken);
    }
}