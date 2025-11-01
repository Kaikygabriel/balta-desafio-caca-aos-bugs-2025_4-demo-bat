using BugStore.Domain.Entities;
using BugStore.Domain.Interfaces;
using BugStore.Infrastructure.Data;

namespace BugStore.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private static AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<Order> RepositoryOrder { get; } = new Repository<Order>(_context);
    public IRepository<Product> RepositoryProduct { get; } = new Repository<Product>(_context);
    public IRepository<Customer> RepositoryCustomer { get; } = new Repository<Customer>(_context);
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void RollBack()
    {
    }
}