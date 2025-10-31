
using BugStore.Application.Requests.Orders;
using BugStore.Domain.Entities;
using MediatorX.Core;
using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Api.Extesions;

public static class MapOrder
{
    public static void UseMapOrder(this WebApplication app)
    {
        app.MapGet("/v1/orders/{id}", async (IMediator mediator, [FromRoute]Guid id) 
            => await mediator.SendAsync(new GetById(id)));
        app.MapPost("/v1/orders", async (IMediator mediator, [FromBody] Order order) =>
        {
            var request = new  Create(order);
            var response= await mediator.SendAsync(request);
            return response.Result ? Results.Created() : Results.BadRequest();
        });
    } 
}