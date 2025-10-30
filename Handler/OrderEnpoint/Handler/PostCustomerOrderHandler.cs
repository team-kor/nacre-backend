using DatabaseEntity.ProductEntity;
using DTO.CustoemrOrderDTO;
using DTO.RecievedCustomerOrderDetailForDisplayDTO;
using Handler.OrderEndpoint.IPostCustomerOrderHandler;
using Handler.OrderEndpoint.Mapper.CustoemrOrderMapper;
using Microsoft.EntityFrameworkCore;
using MigrateDatabase.DatabaseContext;
using SQLitePCL;

namespace Handler.OrderEndpointHandler.PostCustomerOrderHander
{
    public class PostCustomerOrderHanders:IPostCustomerOrderHandler
    {
        private readonly DatabaseContext _database;

        public PostCustomerOrderHanders(DatabaseContext database)
        {
            _database = database;
        }
        public async Task<CustomerOrderDetailForDisplayDTO> InsertNewCustomerOrder(RecievedCustomerOrderDetailDTO receivedCustomerOrder, CancellationToken cancellationToken)
        {
            var allAvailableProduct = receivedCustomerOrder.Item.Select(i => i.ProductID).Distinct().ToList();
            var orderProductDictionary = await _database.Product
                                                .AsNoTracking()
                                                .Where(i => allAvailableProduct.Contains(i.ProductID))
                                                .ToDictionaryAsync(p => p.ProductID);
            var customerDetailsForInserting = CustomerOrderMapper.MapRecievedCustomerOrderDTOToCustomerOrder(receivedCustomerOrder);

            foreach (var orderItem in customerDetailsForInserting.OrderItems)
            {
                orderProductDictionary.TryGetValue(orderItem.ProductID, out Product product); //What this does it looks into the dictionary for the associated productid
                orderItem.ProductSellingPrice = product.SellingPrice;

                orderItem.TotalOrderPriceForItem = orderItem.ProductSellingPrice * orderItem.OrderedQuantity;
            }

            customerDetailsForInserting.TotalOrderPrice = customerDetailsForInserting.OrderItems.Sum(i => i.TotalOrderPriceForItem);
            _database.Orders.Add(customerDetailsForInserting);

            await _database.SaveChangesAsync(cancellationToken);

            return CustomerOrderMapper.MapCustomerOrderToCUstomerOrderDetailsForDisplayDTO(customerDetailsForInserting);
        }
    }
}