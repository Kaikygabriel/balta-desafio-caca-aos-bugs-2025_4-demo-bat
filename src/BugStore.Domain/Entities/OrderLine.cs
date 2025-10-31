using System.Net.Http.Headers;

namespace BugStore.Domain.Entities;

    public class OrderLine : Entity
{

    public OrderLine()
    {
        
    }

    public OrderLine(Guid orderId, int quantity, decimal total, Guid productId, Product product)
    {
        OrderId = orderId;
        Quantity = quantity;
        Total = total;
        ProductId = productId;
        Product = product;
    }

  

    public Guid OrderId { get; set; }
    
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}