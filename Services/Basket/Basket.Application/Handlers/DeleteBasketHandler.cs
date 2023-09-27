using Basket.Application.Commands;
using Basket.Core.Entities.Exceptions;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class DeleteBasketHandler : IRequestHandler<DeleteBasketCommand, Unit>
{
    private readonly IBasketRepository _repository;

    public DeleteBasketHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await _repository.GetBasket(request.UserName);

        if (basket is null)
        {
            throw new BasketNotFoundException(request.UserName);
        }

        await _repository.DeleteBasket(basket.UserName);
        return Unit.Value;
    }
}