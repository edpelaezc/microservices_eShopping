using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Application.Responses;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.API.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<DiscountService> _logger;
    
    public DiscountService(IMediator mediator, ILogger<DiscountService> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var result = await _mediator.Send(new GetDiscountQuery(request.ProductName));
        _logger.LogInformation($"Discount is retrieved for the Product Name: {result.ProductName} and Amount : {result.Amount}");
        return result;
    }
    
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var dto = new CouponDto
        {
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description
        };
        
        var result = await _mediator.Send(new CreateDiscountCommand(dto));
        _logger.LogInformation($"Discount is successfully created for the Product Name: {result.ProductName}");
        
        return result;
    }
    
    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var dto = new CouponForUpdateDto()
        {
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description
        };
        
        var result = await _mediator.Send(new UpdateDiscountCommand(request.Coupon.Id, dto));
        
        _logger.LogInformation($"Discount is successfully created for the Product Name: {result.ProductName}");
        return request.Coupon;
    }
    
    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var cmd = new DeleteDiscountCommand(request.ProductName);
        var deleted = await _mediator.Send(cmd);
        
        var response = new DeleteDiscountResponse
        {
            Success = deleted
        };
        
        _logger.LogInformation($"Delete action result: {deleted}");
        
        return response;
    }
}