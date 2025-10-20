using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using MigrateDatabase.DatabaseContext;
using DTO.CustoemrOrderDTO;
using DTO.CustomerDTO;
using Handler.OrderEndpoint.IPutCustomerOrderHandler;
using Microsoft.EntityFrameworkCore;
using Enum.AvailableEnum;
using Handler.OrderEndpoint.Mapper.CustoemrOrderMapper;

namespace Handler.OrderEndpoint.PutCustomerOrderHander
{
    public class PutCustomerOrderHandlers:IPutCustomerOrderHandlers//Update Order
    {
        private readonly DatabaseContext _database;

        public PutCustomerOrderHandlers(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<CustomerOrderDetailForDisplayDTO> UpdateOrderStatus(int orderID, OrderStatus orderStatus, CancellationToken cancellationToken)
        {
            var currentOrder = await _database.Orders
                                        .Where(o => o.OrderID == orderID)
                                        .FirstOrDefaultAsync(cancellationToken);

            currentOrder.Status = orderStatus.ToString();

            await _database.SaveChangesAsync(cancellationToken);
            return CustomerOrderMapper.MapCustomerOrderToCUstomerOrderDetailsForDisplayDTO(currentOrder);
        } 
    }
}