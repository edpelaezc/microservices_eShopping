using AutoMapper;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class GetOrderListHandler :IRequestHandler<GetOrderListQuery, IList<OrderDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetOrderListHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var orderList = await _repository.Order.GetOrdersByUserName(request.UserName);
        return _mapper.Map<List<OrderDto>>(orderList);
    }
}