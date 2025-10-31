using System.Linq.Expressions;
using BugStore.Domain.Entities;
using BugStore.Domain.Interfaces;

namespace BugStore.Application.Tests.Mocks;

public class FakeRepositoryOrder  :IRepository<Order>
{
    private List<Order> _orders = new()
    {
        new Order
        {
            Id = Guid.Parse("e3f1b2c7-9a4d-4f5a-8c1e-2d7b9f6a1b3c"),
            CustomerId = Guid.NewGuid(),
            CreatedAt = DateTime.Now.AddDays(-5),
            UpdatedAt = DateTime.Now.AddDays(-1),
            Lines = new List<OrderLine>
            {
                new OrderLine { ProductId = Guid.NewGuid(), Quantity = 2 },
                new OrderLine { ProductId = Guid.NewGuid(), Quantity = 1 }
            }
        },
        new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = Guid.NewGuid(),
            CreatedAt = DateTime.Now.AddDays(-3),
            UpdatedAt = DateTime.Now,
            Lines = new List<OrderLine>
            {
                new OrderLine { ProductId = Guid.NewGuid(), Quantity = 5 }
            }
        },
        new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = Guid.NewGuid(),
            CreatedAt = DateTime.Now.AddDays(-1),
            UpdatedAt = DateTime.Now,
            Lines = new List<OrderLine>() 
        }
    };
    public Task<IEnumerable<Order>> GetAll()
    {
        return Task.FromResult<IEnumerable<Order>>(_orders);
    }

    public Task<Order?> GetByPredicate(Expression<Func<Order, bool>> predicate)
    {
        return Task.FromResult<Order?>(_orders.AsQueryable().FirstOrDefault(predicate));
    }

    public void Create(Order entity)
    {
        _orders.Add(entity);
    }

    public void Update(Order entity)
    {
        _orders.Add(entity);
    }

    public void Delete(Order entity)
    {
        _orders.Remove(entity);
    }
}