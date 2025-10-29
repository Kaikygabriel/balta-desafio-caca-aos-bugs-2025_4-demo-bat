using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Requests.Customers;

public record GetById(Guid Id):IRequest<Responses.Customers.GetById>;