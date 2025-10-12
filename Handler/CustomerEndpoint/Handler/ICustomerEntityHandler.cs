using DatabaseEntity.CustomerEntity;
using DTO.CustomerDTO;

namespace Handler.CustomerEndpointHandlers.ICustomerEntityHandler
{
    public interface ICustomerEntityHandlers
    {
        public Task<List<CustomerDTO>> GetAllCustomerDetails(CancellationToken cancellationToken);
        public Task<CustomerDTO?> GetCustomerByID(int id, CancellationToken cancellationToken);
        public Task<CustomerDTO?> UpdateCustomerDetailsByID(int id, RecievedCustomerDTO recievedCustomerDTO, CancellationToken cancellationToken);
        public Task<CustomerDTO?> InsertNewCustomerDetails(RecievedCustomerDTO recievedCustomerDTO, CancellationToken cancellationToken);
        public Task<bool> DeleteCustomerDetails(int id, CancellationToken cancellationToken);
    }
}