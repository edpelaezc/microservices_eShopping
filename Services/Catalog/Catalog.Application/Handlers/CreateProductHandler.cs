using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Entities.Exceptions;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = CatalogMapper.Mapper.Map<Product>(request.product);

        if (productEntity is null)
        {
            throw new ResourceCreationBadRequestException(nameof(request.product));
        }

        await _repository.CreateProduct(productEntity);

        var response = CatalogMapper.Mapper.Map<ProductDto>(productEntity);
        return response;
    }
}