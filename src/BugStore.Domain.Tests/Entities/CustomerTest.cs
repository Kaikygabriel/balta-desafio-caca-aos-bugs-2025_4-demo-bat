using BugStore.Domain.Entities;
using BugStore.Domain.Exceptions;

namespace BugStore.Domain.Tests.Entities;

public class CustomerTest
{
    [Fact]
    public void CreateCustomerWithParametersNull_Return_CustomerException()
    {
        Assert.Throws<CustomerException>(() =>
        {
            new Customer(null, null, null, DateTime.MinValue);
        });
    }
    
    [Fact]
    public void CreateCustomerOk_Return_Ok()
    {
        var customer = new Customer(
            name: "Lucas Almeida",
            email: "lucas.almeida@example.com",
            phone: "+55 11 91234-5678",
            birthDate: new DateTime(1998, 3, 14)
        );
        Assert.Equal(customer.Name,"Lucas Almeida" );
        Assert.Equal(customer.Email,"lucas.almeida@example.com" );
        
    }
}