using MediatR;

namespace Ordering.Application.Commands;

public sealed record DeleteOrderCommand(int Id) : IRequest<Unit>;