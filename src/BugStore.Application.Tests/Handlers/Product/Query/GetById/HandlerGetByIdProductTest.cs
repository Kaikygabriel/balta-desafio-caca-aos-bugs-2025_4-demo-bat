using BugStore.Application.Handlers.Products;
using BugStore.Application.Tests.Mocks;

namespace BugStore.Application.Tests.Handlers.Product.Query.GetById;

public class HandlerGetByIdProductTest
{
    private readonly Handler _handler;

    public HandlerGetByIdProductTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }

    [Fact]
    public async Task GetByIdProductOk_Return_Product()
    {
        var id = "b1f6a6d3-49af-47e7-8e5e-9b56b0182e2a";
        var result = await _handler.HandleAsync(new Requests.Products.GetById(Guid.Parse(id)),CancellationToken.None);
        Assert.IsType<Domain.Entities.Product>(result.Product);
    }
    [Fact]
    public async Task GetByIdProductInvalid_Return_Null()
    {
        var result = await _handler.HandleAsync(new Requests.Products.GetById(Guid.NewGuid()),CancellationToken.None);
        Assert.Equal(null,result.Product);
    }
}