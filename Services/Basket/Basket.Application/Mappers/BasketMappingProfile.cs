using AutoMapper;
using Basket.Application.Responses;
using Basket.Core.Entities;
using EventBus.Messages.Events;

namespace Basket.Application.Mappers;

public class BasketMappingProfile : Profile
{
    public BasketMappingProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();
        CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
    }
}