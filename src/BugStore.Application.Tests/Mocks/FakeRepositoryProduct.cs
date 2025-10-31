using System.Linq.Expressions;
using BugStore.Domain.Entities;
using BugStore.Domain.Interfaces;

namespace BugStore.Application.Tests.Mocks;

public class FakeRepositoryProduct : IRepository<Product>
{
    private List<Product> Products = new()
    {
        
    new Product
    {
        Id = Guid.Parse("b1f6a6d3-49af-47e7-8e5e-9b56b0182e2a"),
        Title = "Camiseta Básica",
        Description = "Camiseta 100% algodão, confortável e leve.",
        Slug = "camiseta-basica",
        Price = 49.90m
    },
    new Product
    {
        Id = Guid.NewGuid(),
        Title = "Tênis Esportivo",
        Description = "Tênis ideal para corridas e caminhadas, com amortecimento reforçado.",
        Slug = "tenis-esportivo",
        Price = 299.99m
    },
    new Product
    {
        Id = Guid.NewGuid(),
        Title = "Relógio Digital",
        Description = "Relógio resistente à água com cronômetro e iluminação noturna.",
        Slug = "relogio-digital",
        Price = 199.50m
    },
    new Product
    {
        Id = Guid.NewGuid(),
        Title = "Fone Bluetooth",
        Description = "Fone sem fio com cancelamento de ruído e bateria de longa duração.",
        Slug = "fone-bluetooth",
        Price = 159.90m
    },
    new Product
    {
        Id = Guid.NewGuid(),
        Title = "Mochila Executiva",
        Description = "Mochila com compartimento para notebook e alças acolchoadas.",
        Slug = "mochila-executiva",
        Price = 229.00m
    }
    };
    public Task<IEnumerable<Product>> GetAll()
    {
        return Task.FromResult<IEnumerable<Product>>(Products);
    }

    public Task<Product?> GetByPredicate(Expression<Func<Product, bool>> predicate)
    {
        return Task.FromResult<Product?>(Products.AsQueryable().FirstOrDefault(predicate));
    }

    public void Create(Product entity)
    {
        Products.Add(entity);
    }

    public void Update(Product entity)
    {
        Products.Add(entity);
    }

    public void Delete(Product entity)
    {
        Products.Remove(entity);
    }
}