using BugStore.Domain.Entities;
using BugStore.Domain.Interfaces;

namespace BugStore.Application.Tests.Mocks;

public class FakeUnitOfWork : IUnitOfWork
{
    public IRepository<Product> RepositoryProduct { get; } = new FakeRepositoryProduct();
    public IRepository<Customer> RepositoryCustomer { get; } = new FakeRepositoryCustomer();
    public IRepository<Order> RepositoryOrder { get; }= new FakeRepositoryOrder();
    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }

    public void RollBack()
    {
        throw new NotImplementedException();
    }
}