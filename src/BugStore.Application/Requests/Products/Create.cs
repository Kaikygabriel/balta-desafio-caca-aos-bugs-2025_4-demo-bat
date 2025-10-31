using BugStore.Domain.Entities;
using MediatorX.Core.Abstraction.Interfaces;
using MediatorX.Core.MediatorX;

namespace BugStore.Application.Requests.Products;

public record Create(Product Product) : IRequest<Responses.Products.Create>;

