using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Entities.Exceptions;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateBasketHandler : IRequestHandler<CreateBasketCommand, ShoppingCartDto>
{
    private readonly IBasketRepository _repository;

    public CreateBasketHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<ShoppingCartDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var entity = BasketMapper.Mapper.Map<ShoppingCart>(request.ShoppingCart);
        var basket = await _repository.UpdateBasket(entity);
        var response = BasketMapper.Mapper.Map<ShoppingCartDto>(basket);
        return response;
    }
}