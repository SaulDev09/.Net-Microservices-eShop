namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/product/{id}",
                async (Guid id, ISender sender) =>
                {
                    var result = await sender.Send(new DeleteProductCommand(id));
                    return Results.Ok(new DeleteProductResponse(result.IsSuccess));
                })
                .WithName("DeleteProduct")
                .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Product")
                .WithDescription("Delete a Product");
        }
    }
}
