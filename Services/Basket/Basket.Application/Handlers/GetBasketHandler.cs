using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Entities.Exceptions;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class GetBasketHandler : IRequestHandler<GetBasketQuery, ShoppingCartDto>
{
    private readonly IBasketRepository _repository;

    public GetBasketHandler(IBasketRepository repository)
    {
        _repository = repository;
    }


    public async Task<ShoppingCartDto> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await _repository.GetBasket(request.UserName);

        if (basket is null)
        {
            throw new BasketNotFoundException(request.UserName);
        }
        
        var response = BasketMapper.Mapper.Map<ShoppingCartDto>(basket);
        return response;
    }
}