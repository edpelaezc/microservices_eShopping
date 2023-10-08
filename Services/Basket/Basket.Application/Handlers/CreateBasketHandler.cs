using Basket.Application.Commands;
using Basket.Application.GrpcService;
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
    private readonly DiscountGrpcService _discountGrpcService;

    public CreateBasketHandler(IBasketRepository repository, DiscountGrpcService discountGrpcService)
    {
        _repository = repository;
        _discountGrpcService = discountGrpcService;
    }

    public async Task<ShoppingCartDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var entity = BasketMapper.Mapper.Map<ShoppingCart>(request.ShoppingCart);
        
        foreach (var item in entity.Items)
        {
            var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;
        }
        
        var basket = await _repository.UpdateBasket(entity);
        
        var response = BasketMapper.Mapper.Map<ShoppingCartDto>(basket);
        return response;
    }
}