using BugStore.Application.Responses.Orders;
using BugStore.Domain.Interfaces;
using MediatorX.Core.Abstraction.Interfaces;
using Create = BugStore.Application.Requests.Orders.Create;
using GetById = BugStore.Application.Requests.Orders.GetById;

namespace BugStore.Application.Handlers.Orders;

public class Handler : HandlerBase,
    IHandler<Create,Responses.Orders.Create>,
    IHandler<GetById,Responses.Orders.GetById>
{
    public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Responses.Orders.Create> HandleAsync(Create request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            _unitOfWork.RepositoryOrder.Create(request.Order);
            await _unitOfWork.CommitAsync();
            return new Responses.Orders.Create(true);
        }
        catch (Exception e)
        {
            return new Responses.Orders.Create(false);
        }
    }

    public async Task<Responses.Orders.GetById> HandleAsync(GetById request, CancellationToken cancellationToken = new CancellationToken())
    {
        return new Responses.Orders.GetById(await _unitOfWork.RepositoryOrder.GetByPredicate(x=>x.Id == request.Id));
    }
}