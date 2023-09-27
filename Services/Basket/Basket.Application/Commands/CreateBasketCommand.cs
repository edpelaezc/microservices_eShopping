using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands;

public sealed record CreateBasketCommand(ShoppingCartDto ShoppingCart) : IRequest<ShoppingCartDto>;
