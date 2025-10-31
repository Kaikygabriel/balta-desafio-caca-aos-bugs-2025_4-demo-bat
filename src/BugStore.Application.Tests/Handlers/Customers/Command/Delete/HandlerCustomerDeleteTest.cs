using BugStore.Application.Handlers.Customers;
using BugStore.Application.Tests.Mocks;
using BugStore.Domain.Entities;

namespace BugStore.Application.Tests.Handlers.Customers.Command.Delete;

public class HandlerCustomerDeleteTest
{
    private readonly Handler _handler;

    public HandlerCustomerDeleteTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    [Theory]
    [MemberData(nameof(DeleteCustomerData))] 
    public async Task HandleDeleteCustomer_ShouldReturnExpectedResult(Requests.Customers.Delete request, bool expectedResult)
    {
        var data = await _handler.HandleAsync(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> DeleteCustomerData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
       
        new object[]
        {
            new Requests.Customers.Delete
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