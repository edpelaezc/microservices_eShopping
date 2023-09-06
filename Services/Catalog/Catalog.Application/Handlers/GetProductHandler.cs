using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository _repository;

    public GetProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetProduct(request.Id);
        var response = CatalogMapper.Mapper.Map<ProductDto>(product);
        return response;
    }
}