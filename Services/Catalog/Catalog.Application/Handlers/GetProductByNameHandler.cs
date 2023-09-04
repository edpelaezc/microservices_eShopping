using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, IList<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetProductByNameHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<ProductDto>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetProductByName(request.productName);
        var response = CatalogMapper.mapper.Map<IList<ProductDto>>(products);
        return response;
    }
}