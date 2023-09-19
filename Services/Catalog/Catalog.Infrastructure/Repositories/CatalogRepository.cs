using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.RequestFeatures;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Extensions;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository : IProductRepository, IBrandRepository, ITypesRepository
{
    private readonly ICatalogContext _context;

    public CatalogRepository(ICatalogContext catalogContext)
    {
        _context = catalogContext;
    }
    
    public async Task<IEnumerable<Product>> GetAllProducts(ProductParameters parameters)
    {
        // filter firts within mongodb api, instead of read all products and then filter.
        var products = await _context
            .Products
            .Filter(parameters)
            .ToListAsync();
        
        var response = products.AsQueryable().Sort(parameters.Sort).ToList();
        
        return PagedList<Product>.ToPagedList(response, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _context
            .Products
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByBrand(string brandName)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Brands!.Name, brandName);
        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task UpdateProduct(Product product)
    {
        await _context
            .Products
            .ReplaceOneAsync(p => p.Id == product.Id, product);
    }

    public async Task DeleteProduct(string id)
    {
        var filter = Builders<Product>.Filter
            .Eq(p => p.Id, id);

        await _context.Products.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        return await _context
            .Brands
            .Find(p => true)
            .ToListAsync();        
    }

    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        return await _context
            .Types
            .Find(p => true)
            .ToListAsync();
    }
}