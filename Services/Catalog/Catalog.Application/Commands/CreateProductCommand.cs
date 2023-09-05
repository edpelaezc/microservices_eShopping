using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Commands;

public sealed record CreateProductCommand(ProductForCreationDto product) : IRequest<ProductDto>;