using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Core.Entities;
using Catalog.Core.Entities.Exceptions;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetProduct(request.Id);

        if (product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }
        
        var updatedProduct = CatalogMapper.mapper.Map(request.product, product);
        await _repository.UpdateProduct(updatedProduct);
        return Unit.Value;
    }
}