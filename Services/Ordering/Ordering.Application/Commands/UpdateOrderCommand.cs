using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Commands;

public sealed record UpdateOrderCommand(OrderDto OrderDto) : IRequest<Unit>;