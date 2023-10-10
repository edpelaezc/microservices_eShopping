using AutoMapper;
using Ordering.Application.Responses;
using Ordering.Core.Entities;

namespace Ordering.Application.Mappers;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderForCreationDto>().ReverseMap();
    }
}