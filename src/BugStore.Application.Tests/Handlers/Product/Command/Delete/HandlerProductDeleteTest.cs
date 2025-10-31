using BugStore.Application.Handlers.Products;
using BugStore.Application.Tests.Mocks;

namespace BugStore.Application.Tests.Handlers.Product.Command.Delete;

public class HandlerProductDeleteTest
{
    private readonly Handler _handler;

    public HandlerProductDeleteTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    [Theory]
    [MemberData(nameof(DeleteProductData))] 
    public async Task HandleDeleteProduct_ShouldReturnExpectedResult(Requests.Products.Delete request, bool expectedResult)
    {
        var data = await _handler.HandleAsync(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> DeleteProductData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
       
        new object[]
        {
            new Requests.Products.Delete
            (
                new Domain.Entities.Product
                {
                    Id = Guid.NewGuid(),
                    Title = "Camiseta Básica",
                    Description = "Camiseta 100% algodão, confortável e leve.",
                    Slug = "camiseta-basica",
                    Price = 49.90m
                }
            ),
            true
        }
    };
}