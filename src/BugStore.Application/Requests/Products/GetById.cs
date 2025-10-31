using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Requests.Products;

public record GetById(Guid Id) :IRequest<Responses.Products.GetById>;