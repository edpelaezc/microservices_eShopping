using MediatR;

namespace Basket.Application.Commands;

public sealed record DeleteBasketCommand(string UserName) : IRequest<Unit>;