using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public sealed record GetAllTypesQuery : IRequest<IList<TypeDto>>;