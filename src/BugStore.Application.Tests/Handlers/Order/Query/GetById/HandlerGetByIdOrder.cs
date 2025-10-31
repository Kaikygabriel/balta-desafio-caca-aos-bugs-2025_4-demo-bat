using BugStore.Application.Handlers.Orders;
using BugStore.Application.Tests.Mocks;

namespace BugStore.Application.Tests.Handlers.Order.Query.GetById;

public class HandlerGetByIdOrder
{
    private readonly Handler _handler;

    public HandlerGetByIdOrder()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }

    [Fact]
    public async Task GetByIdOrderOk_Return_Order()
    {
        var id = Guid.Parse("e3f1b2c7-9a4d-4f5a-8c1e-2d7b9f6a1b3c");
        var result = await _handler.HandleAsync(new Requests.Orders.GetById(id),CancellationToken.None);
        Assert.IsType<Domain.Entities.Order>(result.Order);
    } 
    [Fact]
    public async Task GetByIdOrderinvalid_Return_Order()
    {
        var id = Guid.NewGuid();
        var result = await _handler.HandleAsync(new Requests.Orders.GetById(id),CancellationToken.None);
        Assert.Equal(null,result.Order);
    } 
}