using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Requests.Orders;

public record GetById(Guid Id):IRequest<Responses.Orders.GetById>;