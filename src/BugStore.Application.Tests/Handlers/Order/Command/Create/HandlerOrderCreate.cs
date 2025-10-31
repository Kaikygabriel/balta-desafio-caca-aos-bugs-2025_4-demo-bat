using BugStore.Application.Handlers.Orders;
using BugStore.Application.Tests.Mocks;

namespace BugStore.Application.Tests.Handlers.Order.Command.Create;

public class HandlerOrderCreate
{
    private readonly Handler _handler;

    public HandlerOrderCreate()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    
    [Theory]
    [MemberData(nameof(CreateOrderData))] 
    public async Task HandleCreateOrder_ShouldReturnExpectedResult(Requests.Orders.Create request, bool expectedResult)
    {
        var data = await _handler.HandleAsync(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> CreateOrderData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
        new object[]
        {
            new Requests.Orders.Create
            (
                new Domain.Entities.Order()
                {
                    Id = Guid.NewGuid(),
                }
            ),
            true
        },
    };
} 