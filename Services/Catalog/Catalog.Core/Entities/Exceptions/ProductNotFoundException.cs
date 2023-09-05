namespace Catalog.Core.Entities.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(string Id) : base($"the product with id: {Id} does not exist in db")
    {
    }
}