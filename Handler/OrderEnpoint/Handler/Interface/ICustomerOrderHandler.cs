using DTO.CustoemrOrderDTO;

namespace Handler.OrderEndpoint.IOrderCustomerHandler
{
    public interface ICustomerOrderHandler
    {
        public Task<List<CustomerOrderDetailForDisplayDTO>> GetOrderDetailsByCustomer(int customerId, CancellationToken cancellationToken);
        public Task<CustomerOrderDetailForDisplayDTO> GetOrderDetailsByOrderID(int orderId, CancellationToken cancellationToken);
    }
}