using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypeDto>>
{
    private readonly ITypesRepository _repository;

    public GetAllTypesHandler(ITypesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<TypeDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        var types = await _repository.GetAllTypes();
        var response = 
            CatalogMapper.Mapper.
                Map<IList<ProductType>, IList<TypeDto>>(types.ToList());

        return response;
    }
}