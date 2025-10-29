using BugStore.Domain.Interfaces;

namespace BugStore.Application.Handlers;

public class HandlerBase
{
    protected IUnitOfWork _unitOfWork;

    public HandlerBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}