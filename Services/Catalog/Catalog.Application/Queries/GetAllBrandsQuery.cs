using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public sealed record GetAllBrandsQuery : IRequest<IList<BrandDto>>;
