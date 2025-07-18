﻿namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketResponse(bool IsSuccess);

    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{UserName}",
                async (string UserName, ISender sender) =>
                {
                    var result = await sender.Send(new DeleteBasketCommand(UserName));
                    var response = result.Adapt<DeleteBasketResponse>();
                    return Results.Ok(response);
                    //return Results.Ok(new DeleteBasketResponse(result.IsSuccess));
                })
                .WithName("DeleteBasket")
                .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Basket")
                .WithDescription("Delete a Basket by UserName");
        }
    }
}
