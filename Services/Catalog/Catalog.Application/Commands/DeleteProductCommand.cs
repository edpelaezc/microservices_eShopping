using MediatR;

namespace Catalog.Application.Commands;

public sealed record DeleteProductCommand(string Id) : IRequest<Unit>;