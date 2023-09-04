using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public sealed record GetProductByBrandQuery(string brandName) : IRequest<IList<ProductDto>>;