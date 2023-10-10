using MediatR;
using Ordering.Application.Commands;
using Ordering.Core.Entities.Exceptions;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public DeleteOrderHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _repository
                                    .Order
                                    .FindByCondition(o => o.Id.Equals(request.Id), false)
                                    .SingleOrDefault();

        if (order is null)
        {
            throw new OrderNotFoundException(request.Id);
        }
        
        _repository.Order.Delete(order);
        await _repository.SaveAsync();

        return Unit.Value;
    }
}