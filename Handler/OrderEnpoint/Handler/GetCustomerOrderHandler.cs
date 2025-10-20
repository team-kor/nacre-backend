using DatabaseEntity.CustomerEntity;
using DatabaseEntity.OrderEntity;
using DTO.CustoemrOrderDTO;
using DTO.OrderItemDTO;
using Handler.CustomerEndpointHandlers.Mapper.CustomerEntityMapper;
using Handler.OrderEndpoint.IOrderCustomerHandler;
using Handler.OrderEndpoint.Mapper.CustoemrOrderMapper;
using Microsoft.EntityFrameworkCore;
using MigrateDatabase.DatabaseContext;

namespace Handler.OrderEndpointHandler.GetCustomerOrderHandler
{
    public class GetCustomerOrderHandlers:ICustomerOrderHandler
    {
        private readonly DatabaseContext _database;

        public GetCustomerOrderHandlers(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<List<CustomerOrderDetailForDisplayDTO>> GetOrderDetailsByCustomer(int customerId, CancellationToken cancellationToken)
        {
            var listCustomerOrderDetailForDisplayDTO = await _database.Orders
                                            .AsNoTracking()
                                            .Where(o => o.CustomerID == customerId)
                                            .OrderByDescending(o => o.CreatedDate)
                                            .Select(CustomerOrderMapper.ExpressionOrderToOrderDTO)
                                            .ToListAsync(cancellationToken);
            return listCustomerOrderDetailForDisplayDTO;
        }

        public async Task<CustomerOrderDetailForDisplayDTO> GetOrderDetailsByOrderID(int orderId, CancellationToken cancellationToken)
        {
            var CustomerOrderDetailForDisplayDTO = await _database.Orders
                                        .AsNoTracking()
                                        .Where(o => o.OrderID == orderId)
                                        .Select(CustomerOrderMapper.ExpressionOrderToOrderDTO)
                                        .FirstOrDefaultAsync(cancellationToken);

            return CustomerOrderDetailForDisplayDTO;
        }
    }
}