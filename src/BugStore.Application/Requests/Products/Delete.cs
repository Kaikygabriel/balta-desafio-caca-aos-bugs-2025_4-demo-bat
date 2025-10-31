using BugStore.Domain.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Requests.Products;

public record Delete(Product Product): IRequest<Responses.Products.Delete>;