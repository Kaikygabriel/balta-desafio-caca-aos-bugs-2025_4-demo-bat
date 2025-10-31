using BugStore.Application.Requests.Products;
using BugStore.Domain.Interfaces;
using MediatorX.Core.Abstraction.Interfaces;
using Create = BugStore.Application.Responses.Products.Create;
using Get = BugStore.Application.Responses.Products.Get;
using GetById = BugStore.Application.Responses.Products.GetById;

namespace BugStore.Application.Handlers.Products;

public class Handler  : 
    HandlerBase,
    IHandler<Requests.Products.Create,Responses.Products.Create>,
    IHandler<Requests.Products.Delete,Responses.Products.Delete>,
    IHandler<Requests.Products.Update,Responses.Products.Update>,
    IHandler<Requests.Products.Get,Responses.Products.Get>,
    IHandler<Requests.Products.GetById,Responses.Products.GetById>
{
    public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Responses.Products.Create> HandleAsync(Requests.Products.Create request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            _unitOfWork.RepositoryProduct.Create(request.Product);
            await _unitOfWork.CommitAsync();
            return new Create(true);
        }
        catch (Exception e)
        {
            return new Create(false);
        }
    }
    public async Task<Responses.Products.Delete> HandleAsync(Requests.Products.Delete request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            _unitOfWork.RepositoryProduct.Delete(request.Product);
            await _unitOfWork.CommitAsync();
            return new Responses.Products.Delete(true);
        }
        catch (Exception e)
        {
            return new Responses.Products.Delete(false);
        }
    }
    public async Task<Responses.Products.Update> HandleAsync(Requests.Products.Update request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            _unitOfWork.RepositoryProduct.Update(request.Product);
            await _unitOfWork.CommitAsync();
            return new Responses.Products.Update(true);
        }
        catch (Exception e)
        {
            return new Responses.Products.Update(false);
        }
    }

    public async Task<Get> HandleAsync(Requests.Products.Get request, CancellationToken cancellationToken = new CancellationToken())
    {
        return new Get(await _unitOfWork.RepositoryProduct.GetAll());
    }

    public async Task<GetById> HandleAsync(Requests.Products.GetById request, CancellationToken cancellationToken = new CancellationToken())
    {
        return new GetById(await _unitOfWork.RepositoryProduct.GetByPredicate(x => x.Id == request.Id));
    }
}