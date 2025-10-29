using BugStore.Domain.Entities;

namespace BugStore.Application.Responses.Customers;

public record Get(IEnumerable<Customer>Customers);