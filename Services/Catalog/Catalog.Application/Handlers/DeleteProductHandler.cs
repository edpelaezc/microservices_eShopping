using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities.Exceptions;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _repository.GetProduct(request.Id);

        if (productEntity is null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        await _repository.DeleteProduct(request.Id);
        return Unit.Value;
    }
}