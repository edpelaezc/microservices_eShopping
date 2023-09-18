using Catalog.Application.Responses;
using Catalog.Core.RequestFeatures;
using MediatR;

namespace Catalog.Application.Queries;

public sealed record GetAllProductsQuery(ProductParameters RequestParameters) : IRequest<IList<ProductDto>>;
