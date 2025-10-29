namespace BugStore.Domain.Entities;

public class Order : Entity 
{
    protected Order(){}
    public Order(Guid customerId, Customer customer, DateTime createdAt, DateTime updatedAt)
    {
        CustomerId = customerId;
        Customer = customer;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<OrderLine> Lines { get; set; } = new();
}