using BugStore.Domain.Entities;

namespace BugStore.Application.Responses.Products;

public record Get(IEnumerable<Product>Products);