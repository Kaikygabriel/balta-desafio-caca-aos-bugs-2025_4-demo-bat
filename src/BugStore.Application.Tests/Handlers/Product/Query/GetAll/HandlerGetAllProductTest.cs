using BugStore.Application.Handlers.Products;
using BugStore.Application.Tests.Mocks;

namespace BugStore.Application.Tests.Handlers.Product.Query.GetAll;

public class HandlerGetAllProductTest
{
    private readonly Handler _handler;

    public HandlerGetAllProductTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }

    [Fact]
    public async Task GetAllProducts_Return_ListProducts()
    {
        var result = await _handler.HandleAsync(new Requests.Products.Get(),CancellationToken.None);
        Assert.IsType<List<Domain.Entities.Product>>(result.Products);
    }
}