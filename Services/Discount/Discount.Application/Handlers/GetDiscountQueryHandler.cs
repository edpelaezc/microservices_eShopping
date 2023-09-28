using AutoMapper;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public GetDiscountQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _discountRepository.GetDiscount(request.productName);
        
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with the product name = {request.productName} not found"));
        }

        var response = _mapper.Map<CouponModel>(coupon);
        
        return response;
    }
}