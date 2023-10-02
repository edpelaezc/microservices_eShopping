using AutoMapper;
using Discount.Application.Commands;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class UpdateDiscountHandler : IRequestHandler<UpdateDiscountCommand, CouponModel>
{
    private readonly IDiscountRepository _repository;
    private readonly IMapper _mapper;

    public UpdateDiscountHandler(IDiscountRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = await _repository.GetDiscount(request.CouponForUpdateDto.ProductName);

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with the product name = {request.CouponForUpdateDto.ProductName} not found"));
        }
        
        await _repository.UpdateDiscount(coupon);
        var response = _mapper.Map<CouponModel>(coupon);
        
        return response;
    }
}