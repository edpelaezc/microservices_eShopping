using Catalog.Core.Entities;

namespace Catalog.Application.Responses;

public record ProductDto
{
    public string? Name { get; init; }
    public string? Summary { get; init; }
    public string? Description { get; init; }
    public string? ImageFile { get; init; }
    public ProductBrand? Brands { get; init; }
    public ProductType? Types { get; init; }
    public decimal? price { get; init; }
}