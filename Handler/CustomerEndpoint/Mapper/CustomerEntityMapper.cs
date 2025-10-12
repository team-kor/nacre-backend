using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DatabaseEntity.CustomerEntity;
using DTO.CustomerDTO;

namespace Handler.CustomerEndpointHandlers.Mapper.CustomerEntityMapper
{
    public class CustomerEntityMapper
    
    {
        public static CustomerDTO MapCustomerToCustomerDTO(Customer customer)
        {
            return new CustomerDTO(
                    customer.CustomerID,
                    customer.Name,
                    customer.PhoneNumber,
                    customer.Email,
                    customer.Address,
                    customer.CreatedDate,
                    customer.LastUpdatedDate,
                    customer.ContactPreference);
        }
        public static void CustomerDetailsForUpdate(RecievedCustomerDTO recievedCustomerDTO, Customer customer)
        {
            customer.Name = recievedCustomerDTO.Name;
            customer.PhoneNumber = recievedCustomerDTO.PhoneNumber;
            customer.Email = recievedCustomerDTO.Email;
            customer.Address = recievedCustomerDTO.Address;
            customer.LastUpdatedDate = DateTime.UtcNow;
            customer.ContactPreference = recievedCustomerDTO.ContactPreference;
        }

        public static Customer MapCustomerDTOToCustomerForInsert(RecievedCustomerDTO customerDTO)
        {
            return new Customer
            {
                Name = customerDTO.Name,
                PhoneNumber = customerDTO.PhoneNumber,
                Email = customerDTO.Email,
                Address = customerDTO.Address,
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow,
                ContactPreference = customerDTO.ContactPreference
            };
        }
    }
}