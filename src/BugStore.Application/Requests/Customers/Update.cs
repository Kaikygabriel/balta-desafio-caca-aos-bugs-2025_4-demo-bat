using BugStore.Domain.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Requests.Customers;

public record Update(Customer customer) : IRequest<Responses.Customers.Update>;