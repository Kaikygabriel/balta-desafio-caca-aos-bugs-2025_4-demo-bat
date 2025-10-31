using System.Linq.Expressions;
using BugStore.Domain.Entities;
using BugStore.Domain.Interfaces;

namespace BugStore.Application.Tests.Mocks;

public class FakeRepositoryCustomer : IRepository<Customer>
{
    private List<Customer> _customers = new()
    {
        new Customer
        {
            Id = Guid.Parse("3a2f8f74-9b77-4c8b-8a2f-cc9dbcb2b6b3"),
            Name = "Pedro Souza",
            Email = "pedro.souza@email.com",
            Phone = "(31) 98765-4321",
            BirthDate = new DateTime(1995, 2, 22)
        },
        new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Ana Costa",
            Email = "ana.costa@email.com",
            Phone = "(41) 93456-7890",
            BirthDate = new DateTime(2000, 8, 15)
        },
        new Customer
        {
            Id = Guid.NewGuid(),
            Name = "Lucas Pereira",
            Email = "lucas.pereira@email.com",
            Phone = "(51) 95678-1234",
            BirthDate = new DateTime(1992, 3, 9)
        }
    };
    public Task<IEnumerable<Customer>> GetAll()
    {
        return Task.FromResult<IEnumerable<Customer>>(_customers);
    }

    public Task<Customer?> GetByPredicate(Expression<Func<Customer, bool>> predicate)
    {
        return Task.FromResult<Customer?>(_customers.AsQueryable().FirstOrDefault(predicate));
    }

    public void Create(Customer entity)
    {
        _customers.Add(entity);
    }

    public void Update(Customer entity)
    {
        _customers.Add(entity);
    }

    public void Delete(Customer entity)
    {
        _customers.Remove(entity);
    }
}