using Microsoft.AspNetCore.Mvc;
using DTO.CustomerDTO;
using Handler.CustomerEndpointHandlers.ICustomerEntityHandler;
using DatabaseEntity.CustomerEntity;

namespace Hanlder.CustomerEndpointHandlers.SetUpEndpoint.SetUpCustomerEndpoint
{
    public static class SetUpCustomerEndpoint
    {
        public static IEndpointRouteBuilder SetUp(this IEndpointRouteBuilder app)
        {
            RouteGroupBuilder group = app.MapGroup("/customer");

            group.MapGet("/", async Task<IResult> 
            (
                [FromServices] ICustomerEntityHandlers customerHandlers, CancellationToken cancellationToken
            ) =>
            {
                var result = await customerHandlers.GetAllCustomerDetails(cancellationToken);
                return Results.Ok(result);
            });

            group.MapGet("/{id:int}", async Task<IResult> 
            (
                int id, [FromServices] ICustomerEntityHandlers customerEntityHandlers, CancellationToken cancellationToken
            ) =>
            {
                CustomerDTO customerById = await customerEntityHandlers.GetCustomerByID(id, cancellationToken);
                return Results.Ok(customerById);
            }).WithName("SingleCustomer");

            group.MapPut("/{id:int}", async Task<IResult>
            (
                int id,
                RecievedCustomerDTO recievedDetails,
                [FromServices] ICustomerEntityHandlers customerEntityHandler,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await customerEntityHandler.UpdateCustomerDetailsByID(id, recievedDetails, cancellationToken);
                return (result == null) ? TypedResults.NotFound() : TypedResults.Ok(result);
            });

            group.MapPost("/", async Task<IResult>
            (
                RecievedCustomerDTO recievedDetails,
                [FromServices] ICustomerEntityHandlers customerEntityHandler,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await customerEntityHandler.InsertNewCustomerDetails(recievedDetails, cancellationToken);
                return Results.CreatedAtRoute("SingleCustomer", new { id = result.CustomerID }, result);
            });

            group.MapDelete("/{id:int}", async Task<IResult>
            (
                int id,
                [FromServices] ICustomerEntityHandlers customerEntityHandler,
            CancellationToken cancellationToken
            ) =>
            {
                var result = await customerEntityHandler.DeleteCustomerDetails(id, cancellationToken);
                return result ? Results.Ok() : Results.NotFound();
            });

            return group;
        }
    }
}
