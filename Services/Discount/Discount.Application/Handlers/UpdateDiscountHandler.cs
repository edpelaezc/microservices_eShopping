using AutoMapper;
using Discount.Application.Commands;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class UpdateDiscountHandler : IRequestHandler<UpdateDiscountCommand, Unit>
{
    private readonly IDiscountRepository _repository;

    public UpdateDiscountHandler(IDiscountRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = await _repository.GetDiscount(request.CouponForUpdateDto.ProductName);

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with the product name = {request.CouponForUpdateDto.ProductName} not found"));
        }
        
        await _repository.UpdateDiscount(coupon);
        return Unit.Value;
    }
}