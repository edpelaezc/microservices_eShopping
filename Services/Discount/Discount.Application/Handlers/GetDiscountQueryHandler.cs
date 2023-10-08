using AutoMapper;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
{
    private readonly IDiscountRepository _repository;

    public GetDiscountQueryHandler(IDiscountRepository repository, IMapper mapper)
    {
        _repository = repository;
    }

    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _repository.GetDiscount(request.productName);
        
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with the product name = {request.productName} not found"));
        }

        var response = new CouponModel
        {
            Id = coupon.Id,
            Amount = coupon.Amount,
            Description = coupon.Description,
            ProductName = coupon.ProductName
        };
        
        return response;
    }
}