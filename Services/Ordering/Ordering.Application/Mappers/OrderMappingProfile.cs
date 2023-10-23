using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Commands;
using Ordering.Application.Responses;
using Ordering.Core.Entities;

namespace Ordering.Application.Mappers;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderForCreationDto>().ReverseMap();
        CreateMap<BasketCheckoutEvent, OrderForCreationDto>().ReverseMap();
        CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
    }
}