using BugStore.Application.Handlers.Customers;
using BugStore.Application.Tests.Mocks;
using BugStore.Domain.Entities;

namespace BugStore.Application.Tests.Handlers.Customers.Command.Update;

public class HandlerCustomerUpdate
{
    private readonly Handler _handler;

    public HandlerCustomerUpdate()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    [Theory]
    [MemberData(nameof(UpdateCustomerData))] 
    public async Task HandleUpdateCustomer_ShouldReturnExpectedResult(Requests.Customers.Update request, bool expectedResult)
    {
        var data = await _handler.HandleAsync(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> UpdateCustomerData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
       
        new object[]
        {
            new Requests.Customers.Update
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