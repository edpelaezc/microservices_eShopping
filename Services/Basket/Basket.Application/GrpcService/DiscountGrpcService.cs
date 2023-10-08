using Discount.Grpc.Protos;

namespace Basket.Application.GrpcService;

public class DiscountGrpcService
{
    private readonly DiscountProtoService.DiscountProtoServiceClient _client;

    public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient client)
    {
        _client = client;
    }
    
    public async Task<CouponModel> GetDiscount(string productName)
    {
        return await _client.GetDiscountAsync(new GetDiscountRequest {ProductName = productName});
    }
}