using BugStore.Domain.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Requests.Orders;

public record Create(Order Order): IRequest<Responses.Orders.Create>;