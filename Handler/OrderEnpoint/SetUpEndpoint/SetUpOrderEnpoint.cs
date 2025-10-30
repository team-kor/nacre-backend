using Microsoft.AspNetCore.Mvc;
using Handler.OrderEndpoint.IOrderCustomerHandler;
using DTO.RecievedCustomerOrderDetailForDisplayDTO;
using Handler.OrderEndpoint.IPostCustomerOrderHandler;
using Enum.AvailableEnum;
using Handler.OrderEndpoint.IPutCustomerOrderHandler;

namespace OrderEndpoint.Handler.SetUpEndpoint.SetUpOrderEndpoint
{
    public static class SetupOrderEndpoint
    {
        public static IEndpointRouteBuilder SetUpOrderEndPoints(this IEndpointRouteBuilder app)
        {
            RouteGroupBuilder group = app.MapGroup("/order");

            group.MapGet("/", async Task<IResult>
            (
                [FromServices] ICustomerOrderHandler getCustomerOrderHandler,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await getCustomerOrderHandler.GetAllCustomerOrderDetails(cancellationToken);
                return Results.Ok(result);
            });

            group.MapGet("/customerid/{id:int}", async Task<IResult>
            (
                int customerId,
                [FromServices] ICustomerOrderHandler getCustomerOrderHandler,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await getCustomerOrderHandler.GetOrderDetailsByCustomer(customerId, cancellationToken);
                return Results.Ok(result);
            });

            group.MapGet("/{orderId:int}", async Task<IResult>
            (
                int orderId,
                [FromServices] ICustomerOrderHandler getCustomerOrderHandler,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await getCustomerOrderHandler.GetOrderDetailsByOrderID(orderId, cancellationToken);
                return Results.Ok(result);
            }).WithName("singleorder");

            group.MapPost("/", async Task<IResult>
            (
                RecievedCustomerOrderDetailDTO recievedOrder,
                [FromServices] IPostCustomerOrderHandler postCustomerOrderHandler,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await postCustomerOrderHandler.InsertNewCustomerOrder(recievedOrder, cancellationToken);
                return Results.CreatedAtRoute("singleorder", new {orderid = result.OrderID }, result);
            });

            group.MapPut("/{orderId:int}", async Task<IResult>
            (
                int orderId,
                OrderStatus orderStatus,
                [FromServices] IPutCustomerOrderHandlers putCustomerOrderHandler,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await putCustomerOrderHandler.UpdateOrderStatus(orderId, orderStatus, cancellationToken);
                return Results.Ok(result);
            });

            return group;
        }
    }
}