using DTO.ProductDTO;
using Handler.ProductEndpoint.IProductHandler;
using Microsoft.AspNetCore.Mvc;

namespace Handler.ProductEndpoint.SetUpEndpoint.SetUpProductEndpoint
{
    public static class SetUpProductEndpoint
    {
        public static IEndpointRouteBuilder SetUpProductEndpoints(this IEndpointRouteBuilder app)
        {
            RouteGroupBuilder group = app.MapGroup("/product");

            group.MapGet("/", async Task<IResult>
            (
                [FromServices] IProductHandlers productHandlers,
                CancellationToken cancellationToken
            ) =>
            {
                var results = await productHandlers.GetAllProductDetails(cancellationToken);
                return Results.Ok(results);
            });

            group.MapGet("/{id:int}", async Task<IResult>
            (
                int id,
                [FromServices] IProductHandlers productHandlers,
                CancellationToken cancellationToken
            ) =>
            {
                var results = await productHandlers.GetProductByID(id, cancellationToken);
                return Results.Ok(results);
            }).WithName("SingleProduct");

            group.MapPut("/{id:int}", async Task<IResult>
            (
                int id,
                RecievedProductDTO recievedProduct,
                [FromServices] IProductHandlers productHandlers,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await productHandlers.UpdateProductDetailsByID(id, recievedProduct, cancellationToken);
                return (result == null) ? Results.NotFound() : Results.Ok(result);
            });

            group.MapPost("/", async Task<IResult>
            (
                RecievedProductDTO recievedProduct,
                [FromServices] IProductHandlers productHandlers,
                CancellationToken cancellationToken
            ) =>
            {
                var result = await productHandlers.InsertNewProductDetails(recievedProduct, cancellationToken);
                return Results.CreatedAtRoute("SingleProduct", new { id = result.ProductID }, result);
            });

            group.MapDelete("/{id:int}", async Task<IResult>
            (int id,
            [FromServices] IProductHandlers productHandlers,
            CancellationToken cancellationToken) =>
            {
                var result = await productHandlers.DeleteProductDetails(id, cancellationToken);
                return result ? Results.Ok() : Results.NotFound();
            });

            return group;
        }
    }
}