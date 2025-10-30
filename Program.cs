using System;
using Handler.CustomerEndpointHandlers.ICustomerEntityHandler;
using Microsoft.VisualBasic;
using Handler.CustomerEndpointHandlers.CustomerEntityHandler;
using Handler.ProductEndpoint.IProductHandler;
using Handler.ProductEndpoint.ProductHandler;
using Handler.OrderEndpoint.IOrderCustomerHandler;
using Handler.OrderEndpointHandler.GetCustomerOrderHandler;
using Handler.OrderEndpoint.IPostCustomerOrderHandler;
using Handler.OrderEndpointHandler.PostCustomerOrderHander;
using Handler.OrderEndpoint.IPutCustomerOrderHandler;
using Handler.OrderEndpoint.PutCustomerOrderHander;
using System.Text.Json.Serialization;
using System.Data.Common;
using MigrateDatabase.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Handler.ProductEndpoint.SetUpEndpoint.SetUpProductEndpoint;
using Hanlder.CustomerEndpointHandlers.SetUpEndpoint.SetUpCustomerEndpoint;
using OrderEndpoint.Handler.SetUpEndpoint.SetUpOrderEndpoint;
using DatabaseEntity.ProductEntity;
using Enum.AvailableEnum;
using DatabaseEntity.ProductInventory;
using DatabaseEntity.CustomerEntity;
using System.Threading.Tasks;

namespace NacreProj
{
    public class MainProgram
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<ICustomerEntityHandlers, CustomerHandlers>();
            builder.Services.AddScoped<IProductHandlers, ProductHandlers>();
            builder.Services.AddScoped<ICustomerOrderHandler, GetCustomerOrderHandlers>();
            builder.Services.AddScoped<IPostCustomerOrderHandler, PostCustomerOrderHanders>();
            builder.Services.AddScoped<IPutCustomerOrderHandlers, PutCustomerOrderHandlers>();
            builder.Services.ConfigureHttpJsonOptions(o =>
            {
                o.SerializerOptions.Converters.Add(
                    new JsonStringEnumConverter(allowIntegerValues: false)
                    );
            });

            builder.Services.AddDbContext<DatabaseContext>(option =>
            option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                if (!db.Product.Any())
                {
                    db.Product.AddRange(
                    new Product
                    {
                        ProductName = "Withat Brush Cleaner",
                        ProductGroupType = ProductGroupType.Cleanser.ToString(),
                        BoughtPrice = 5.76m,
                        SellingPrice = 8.99m,
                        ProductDescription = "100g, for sensitive skin",
                        Status = ProductStatus.Active.ToString(),
                        productInventory = new ProductInventories
                        {
                            AvailableQuantity = 100,
                            ReserveQuantity = 0
                        }
                    });
                }

                if (!db.Customer.Any())
                {
                    db.Customer.AddRange(
                        new Customer
                        {
                            Name = "John",
                            PhoneNumber = "021 21 25 307",
                            Email = "test@email.com",
                            Address = "House1",
                            ContactPreference = CustomerContactPreference.Phone.ToString(),
                            LastUpdatedDate = DateTime.UtcNow,
                            CreatedDate = DateTime.UtcNow
                        }
                    );
                }

                await db.SaveChangesAsync();
            }

            app.SetUpProductEndpoints();
            app.SetUpCustomerEndpoints();
            app.SetUpOrderEndPoints();

            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.Run();
        }
    }
}