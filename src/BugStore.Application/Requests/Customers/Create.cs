using BugStore.Domain.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Requests.Customers;

public record Create(Customer Customer) : IRequest<Responses.Customers.Create>;