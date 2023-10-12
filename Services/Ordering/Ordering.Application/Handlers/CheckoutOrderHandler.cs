using AutoMapper;
using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CheckoutOrderHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<OrderDto> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Order>(request.OrderForCreationDto);
        _repository.Order.Create(entity);
        await _repository.SaveAsync();

        var response = _mapper.Map<OrderDto>(entity);
        return response;
    }
}