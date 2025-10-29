using BugStore.Domain.Entities;
using BugStore.Domain.Exceptions;

namespace BugStore.Domain.Tests.Entities;

public class ProductTest
{
    [Fact]
    public void CreateProductWithParametersNull_Return_ProductException()
    {
        Assert.Throws<ProductException>(() =>
        {
            new Product(null, null, null, 0);
        });
    }
    
    [Fact]
    public void CreateProductOk_Return_Ok()
    {
        var product = new Product("teste", "teste", "TESTE", 13);
        Assert.Equal("teste",product.Title);
    }
}