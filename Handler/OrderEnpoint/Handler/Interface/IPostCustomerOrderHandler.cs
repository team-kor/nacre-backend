using DTO.CustoemrOrderDTO;
using DTO.CustomerDTO;
using DTO.RecievedCustomerOrderDetailForDisplayDTO;

namespace Handler.OrderEndpoint.IPostCustomerOrderHandler
{
    public interface IPostCustomerOrderHandler
    {
        public Task<CustomerOrderDetailForDisplayDTO> InsertNewCustomerOrder(RecievedCustomerOrderDetailDTO recievedCustomerOrder, CancellationToken cancellationToken);
    }
}