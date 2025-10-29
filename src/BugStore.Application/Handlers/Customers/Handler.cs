using BugStore.Application.Requests.Customers;
using BugStore.Domain.Entities;
using BugStore.Domain.Interfaces;
using MediatorX.Core.Abstraction.Interfaces;

namespace BugStore.Application.Handlers.Customers;

public class Handler:
    HandlerBase,
    IHandler<Create,Responses.Customers.Create>,
    IHandler<Delete,Responses.Customers.Delete>,
    IHandler<Update,Responses.Customers.Update>,
    IHandler<Get,Responses.Customers.Get>,
    IHandler<GetById,Responses.Customers.GetById>
{
    public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Responses.Customers.Create> HandleAsync(Create request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            _unitOfWork.RepositoryCustomer.Create(request.Customer);
            await _unitOfWork.CommitAsync();
            return new Responses.Customers.Create(true);
        }
        catch (Exception e)
        {
            return new Responses.Customers.Create(false);
        }
    }

    public async Task<Responses.Customers.Delete> HandleAsync(Delete request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            _unitOfWork.RepositoryCustomer.Delete(request.Customer);
            await _unitOfWork.CommitAsync();
            return new Responses.Customers.Delete(true); 
        }
        catch (Exception e)
        {
            return new Responses.Customers.Delete(false); 
        }
    }

    public async Task<Responses.Customers.Update> HandleAsync(Update request,CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            _unitOfWork.RepositoryCustomer.Update(request.customer);
            await _unitOfWork.CommitAsync();
            return new Responses.Customers.Update(true);
        }
        catch (Exception e)
        {
            return new Responses.Customers.Update(false);
        }
    }
    
    public async Task<Responses.Customers.Get> HandleAsync(Get request, CancellationToken cancellationToken = new CancellationToken())
    {
        return new Responses.Customers.Get(await _unitOfWork.RepositoryCustomer.GetAll());
    }
    
    public async Task<Responses.Customers.GetById> HandleAsync(GetById request, CancellationToken cancellationToken = new CancellationToken())
    {
        var customer = await _unitOfWork.RepositoryCustomer.GetByPredicate(x => x.Id == request.Id);
        return new Responses.Customers.GetById(customer);
    }
}