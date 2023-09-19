using Catalog.Core.Entities;
using Catalog.Core.RequestFeatures;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts(ProductParameters parameters);
    Task<Product> GetProduct(string id);
    Task<IEnumerable<Product>> GetProductByName(string name);
    Task<IEnumerable<Product>> GetProductByBrand(string brandName);
    Task CreateProduct(Product product);    
    Task UpdateProduct(Product product);
    Task DeleteProduct(string id);
}