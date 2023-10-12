using AutoMapper;
using MediatR;
using Ordering.Application.Commands;
using Ordering.Core.Entities.Exceptions;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateOrderHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _repository
            .Order
            .FindByCondition(o => o.Id.Equals(request.id), true)
            .SingleOrDefault();

        if (order is null)
        {
            throw new OrderNotFoundException(request.id);
        }

        _mapper.Map(request.OrderDto, order);
        await _repository.SaveAsync();

        return Unit.Value;
    }
}