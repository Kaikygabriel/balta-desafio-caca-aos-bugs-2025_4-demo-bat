
using BugStore.Application.Requests.Products;
using BugStore.Domain.Entities;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BugStore.Api.Extesions;

public static class MapProducts
{
    public static void UseMapProducts(this WebApplication app)
    {
        
        app.MapGet("/v1/products",async (IMediator mediator)
            => await mediator.SendAsync(new Get()));
        app.MapGet("/v1/products/{id}", async (IMediator mediator,[FromRoute]Guid id)
            => await mediator.SendAsync(new GetById(id)));
        app.MapPost("/v1/products", async (IMediator mediator, [FromBody] Product product) =>
        {
            var request = new  Create(product);
            var response= await mediator.SendAsync(request);
            return response.Result ? Results.Created() : Results.BadRequest();
        });
        app.MapPut("/v1/products/{id}", async (IMediator mediator, [FromRoute] Guid id, [FromBody] Product product) =>
        {
            var resultGetById = await mediator.SendAsync(new GetById(id));
            if (resultGetById is null|| id != product.Id)
                Results.NotFound();
    
            var resultUpdateCostumer = await mediator.SendAsync(new Update(resultGetById.Product));
            return resultUpdateCostumer.Result ? Results.Ok() : Results.BadRequest();

        });
        app.MapDelete("/v1/products/{id}", async (IMediator mediator, [FromRoute] Guid id) =>
        {
            var resultGetById = await mediator.SendAsync(new GetById(id));
            if (resultGetById is null)
                Results.NotFound();
            var resultDeleteCostumer = await mediator.SendAsync(new Delete(resultGetById.Product));
            return resultDeleteCostumer.Result ? Results.Ok() : Results.BadRequest();
        });


    }
}