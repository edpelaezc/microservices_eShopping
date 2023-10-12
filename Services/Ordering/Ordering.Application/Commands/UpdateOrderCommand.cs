using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Commands;

public sealed record UpdateOrderCommand(int id, OrderDto OrderDto) : IRequest<Unit>;