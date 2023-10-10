using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Commands;

public sealed record CheckoutOrderCommand(OrderForCreationDto OrderForCreationDto) : IRequest<int>;