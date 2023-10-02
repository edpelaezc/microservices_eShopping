using Discount.Application.Commands;
using Discount.Core.Repositories;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class DeleteDiscountHandler : IRequestHandler<DeleteDiscountCommand, bool>
{
    private readonly IDiscountRepository _repository;

    public DeleteDiscountHandler(IDiscountRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = await _repository.GetDiscount(request.productName);

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with the product name = {request.productName} not found"));
        }
        
        var response = await _repository.DeleteDiscount(request.productName);
        return response;
    }
}