using Microsoft.EntityFrameworkCore.Storage;
using MigrateDatabase.DatabaseContext;
using DatabaseEntity.CustomerEntity;
using Microsoft.EntityFrameworkCore;
using DTO.CustomerDTO;
using Handler.CustomerEndpointHandlers.Mapper.CustomerEntityMapper;
using Handler.CustomerEndpointHandlers.ICustomerEntityHandler;

namespace Handler.CustomerEndpointHandlers.CustomerEntityHandler
{
    public class CustomerHandlers:ICustomerEntityHandlers
    {
        private readonly DatabaseContext _database;

        public CustomerHandlers (DatabaseContext database)
        {
            _database = database;
        }
        public async Task<List<CustomerDTO>> GetAllCustomerDetails(CancellationToken cancellationToken = default)
        {
            List<Customer> availableCustomer = await _database.Customer.AsNoTracking().ToListAsync(cancellationToken);
            return availableCustomer.Select(CustomerEntityMapper.MapCustomerToCustomerDTO).ToList();
        }

        public async Task<CustomerDTO?> GetCustomerByID(int id, CancellationToken cancellationToken = default)
        {
            Customer customer = await _database.Customer.AsNoTracking().FirstOrDefaultAsync(customerId => customerId.CustomerID == id, cancellationToken);
            if (customer == null)
            {
                return null;
            }
            return CustomerEntityMapper.MapCustomerToCustomerDTO(customer);
        }

        public async Task<CustomerDTO?> UpdateCustomerDetailsByID(int id, RecievedCustomerDTO recievedCustomerDTO, CancellationToken cancellationToken = default)
        {
            Customer existingCustomer = await _database.Customer.FindAsync(id, cancellationToken);
            if (existingCustomer == null)
            {
                return null;
            }
            CustomerEntityMapper.CustomerDetailsForUpdate(recievedCustomerDTO, existingCustomer);

            await _database.SaveChangesAsync(cancellationToken);

            return CustomerEntityMapper.MapCustomerToCustomerDTO(existingCustomer);
        }

        public async Task<CustomerDTO?> InsertNewCustomerDetails(RecievedCustomerDTO recievedCustomerDTO, CancellationToken cancellationToken = default)
        {
            Customer createdCustomer = CustomerEntityMapper.MapCustomerDTOToCustomerForInsert(recievedCustomerDTO);
            await _database.Customer.AddAsync(createdCustomer, cancellationToken);
            await _database.SaveChangesAsync(cancellationToken);
            return CustomerEntityMapper.MapCustomerToCustomerDTO(createdCustomer);
        }

        public async Task<bool> DeleteCustomerDetails(int id, CancellationToken cancellationToken)
        {
            Customer existingCustomer = await _database.Customer.FindAsync(id, cancellationToken);
            if (existingCustomer == null)
            {
                return false;
            }
            _database.Customer.Remove(existingCustomer);
            await _database.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
