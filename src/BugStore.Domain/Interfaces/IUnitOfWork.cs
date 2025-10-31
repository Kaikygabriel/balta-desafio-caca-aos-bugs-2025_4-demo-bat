using BugStore.Domain.Entities;

namespace BugStore.Domain.Interfaces;

public interface IUnitOfWork
{
    public IRepository<Order> RepositoryOrder { get;}

    public IRepository<Product> RepositoryProduct { get;}

    public IRepository<Customer> RepositoryCustomer { get;}
    Task CommitAsync();
    void RollBack();
}