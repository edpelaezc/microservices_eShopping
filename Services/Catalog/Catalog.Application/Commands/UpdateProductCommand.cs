using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Commands;

public sealed record UpdateProductCommand(string Id, ProductForCreationDto product) : IRequest<Unit>;