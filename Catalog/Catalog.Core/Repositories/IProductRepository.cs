using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProduct(string id);
    Task<IEnumerable<Product>> GetProductByName(string name);
    Task<IEnumerable<Product>> GetProductByBrand(string brandName);
    void CreateProduct(Product product);    
    void UpdateProduct(Product product);
    void DeleteProduct(string id);
}