namespace Catalog.Core.RequestFeatures;

public class ProductParameters : RequestParameters
{
    public string? BrandId { get; set; }
    public string? TypeId { get; set; }
    public string? Sort { get; set; }
    public string? SearchTerm { get; set; }
}