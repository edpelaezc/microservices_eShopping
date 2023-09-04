using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public sealed record GetProductQuery(string Id) : IRequest<ProductDto>;