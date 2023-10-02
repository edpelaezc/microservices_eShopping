using AutoMapper;
using Discount.Application.Responses;
using Discount.Core.Entities;
using Discount.Grpc.Protos;

namespace Discount.Application.Mappers;

public class DiscountProfile : Profile
{
    public DiscountProfile()
    {
        CreateMap<Coupon, CouponModel>().ReverseMap();
        CreateMap<Coupon, CouponDto>().ReverseMap();
    }
}