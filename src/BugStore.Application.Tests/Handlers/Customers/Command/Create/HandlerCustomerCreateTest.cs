using BugStore.Application.Handlers.Customers;
using BugStore.Application.Tests.Mocks;
using BugStore.Domain.Entities;

namespace BugStore.Application.Tests.Handlers.Customers.Command.Create;

public class HandlerCustomerCreateTest
{
    private readonly Handler _handler;

    public HandlerCustomerCreateTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    [Theory]
    [MemberData(nameof(CreateCustomerData))] 
    public async Task HandleCreateCustomer_ShouldReturnExpectedResult(Requests.Customers.Create request, bool expectedResult)
    {
        var data = await _handler.HandleAsync(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> CreateCustomerData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
        new object[]
        {
            new Requests.Customers.Create
            (
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    BirthDate   = DateTime.Now,
                    Email = "email@teste",
                    Name = "teste"
                }
            ),
            true
        }
    };
}