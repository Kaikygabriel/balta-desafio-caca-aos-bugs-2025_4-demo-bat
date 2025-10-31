
using BugStore.Application.Requests.Customers;
using BugStore.Domain.Entities;
using MediatorX.Core;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Api.Extesions;

public static class MapCustomers
{
    public static void UseMapCustomers(this WebApplication app)
    {
        
        app.MapGet("/v1/customers", async (IMediator mediator)
            => await mediator.SendAsync(new Get()));
        app.MapGet("/v1/customers/{id}", async (IMediator mediator,[FromRoute]Guid id) 
            => await mediator.SendAsync(new GetById(id)));
        app.MapPost("/v1/customers", async (IMediator mediator,[FromBody] Customer customer) =>
        {
            var request = new  Create(customer);
            var response= await mediator.SendAsync(request);
            return response.Result ? Results.Created() : Results.BadRequest();
        });
        app.MapPut("/v1/customers/{id}",async (IMediator mediator,[FromRoute]Guid id,[FromBody]Customer customer)  =>
        {
            var resultGetById = await mediator.SendAsync(new GetById(id));
            if (resultGetById is null|| id != customer.Id)
                Results.NotFound();
    
            var resultUpdateCostumer = await mediator.SendAsync(new Update(resultGetById.customer));
            return resultUpdateCostumer.Result ? Results.Ok() : Results.BadRequest();
        });
        app.MapDelete("/v1/customers/{id}", async (IMediator mediator,[FromRoute]Guid id)=>
        {
            var resultGetById = await mediator.SendAsync(new GetById(id));
            if (resultGetById is null)
                Results.NotFound();
            var resultDeleteCostumer = await mediator.SendAsync(new Delete(resultGetById.customer));
            return resultDeleteCostumer.Result ? Results.Ok() : Results.BadRequest();
        });

    } 
}