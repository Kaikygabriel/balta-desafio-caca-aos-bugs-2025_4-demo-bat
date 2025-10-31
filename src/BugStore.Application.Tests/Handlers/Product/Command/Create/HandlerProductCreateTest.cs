using BugStore.Application.Handlers.Products;
using BugStore.Application.Tests.Mocks;

namespace BugStore.Application.Tests.Handlers.Product.Command.Create;

public class ProductHandlerTests
{
    private readonly Handler _handler;

    public ProductHandlerTests()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }

    [Theory]
    [MemberData(nameof(CreateProductData))] 
    public async Task HandleCreateProduct_ShouldReturnExpectedResult(Requests.Products.Create request, bool expectedResult)
    {
        var data = await _handler.HandleAsync(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> CreateProductData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
        new object[]
        {
            new Requests.Products.Create
            (
                new Domain.Entities.Product
                {
                    Description = "teste",
                    Id = Guid.NewGuid(),
                    Price = 13,
                    Slug = "teste",
                    Title = "teste"
                }
            ),
            true
        },
        new object[]
        {
            new Requests.Products.Create
            (
                new Domain.Entities.Product
                {
                    Description = "teste2",
                    Id = Guid.NewGuid(),
                    Price = 23,
                    Slug = "teste2",
                    Title = "teste2"
                }
            ),
            true
        }
    };
}