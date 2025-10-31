using BugStore.Domain.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Requests.Products;

public record Update(Product Product):  IRequest<Responses.Products.Update>;