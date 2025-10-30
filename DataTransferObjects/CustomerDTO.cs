using DatabaseEntity.CustomerEntity;

namespace DTO.CustomerDTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string ContactPreference { get; set; }

        public CustomerDTO(
            int customerID,
            string name,
            string phoneNumber,
            string email,
            string address,
            DateTime createDate,
            DateTime lastUpdateDate,
            string contactPreferece
        )
        {
            CustomerID = customerID;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            CreatedDate = createDate;
            LastUpdatedDate = lastUpdateDate;
            ContactPreference = contactPreferece;
        }
    }

    public class RecievedCustomerDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactPreference { get; set; }

        public RecievedCustomerDTO(
            string name,
            string phoneNumber,
            string email,
            string address,
            string contactPreference
        )
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            ContactPreference = contactPreference;
        }
    }
}