using System.Net;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class CatalogController : ApiController
{
    private readonly IMediator _mediator;
    
    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Gets all the products stored in mongo database.
    /// </summary>
    /// <returns>List of products</returns>
    [HttpGet("products")]
    [ProducesResponseType(typeof(IList<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts([FromQuery] ProductParameters requestParameters)
    {
        var products = await _mediator.Send(new GetAllProductsQuery(requestParameters));
        return Ok(products);
    }
    
    /// <summary>
    /// Gets a product by a provided ID
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>Product object</returns>
    [HttpGet("products/{id}", Name = "ProductById")]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await _mediator.Send(new GetProductQuery(id));
        return Ok(product);
    }
    
    /// <summary>
    /// Gets a product by a provided product name
    /// </summary>
    /// <param name="name">Product Name</param>
    /// <returns>Product object</returns>
    [HttpGet("products/[action]/{name}", Name = "ProductsByName")]
    [ProducesResponseType(typeof(IList<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByName(string name)
    {
        var products = await _mediator.Send(new GetProductByNameQuery(name));
        return Ok(products);
    }
    
    /// <summary>
    /// Gets a product by a provided product brand
    /// </summary>
    /// <param name="brand">Product Brand</param>
    /// <returns>Product object</returns>
    [HttpGet("products/[action]/{brand}", Name = "ProductsByBrand")]
    [ProducesResponseType(typeof(IList<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByBrand(string brand)
    {
        var products = await _mediator.Send(new GetProductByBrandQuery(brand));
        return Ok(products);
    }
    
    /// <summary>
    /// Creates a new product
    /// </summary>
    /// <param name="productForCreationDto"></param>
    /// <returns>Newly created product</returns>
    [HttpPost("products")]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto productForCreationDto)
    {
        var product = await _mediator.Send(new CreateProductCommand(productForCreationDto));

        return CreatedAtRoute("ProductById", new { id = product.Id }, product);
    }
    
    /// <summary>
    /// Updates a product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="productForCreationDto"></param>
    /// <returns></returns>
    [HttpPut("products/{id}")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductForCreationDto productForCreationDto)
    {
        if (productForCreationDto is null)
        {
            return BadRequest("ProductForCreationDto is null");
        }
        
        await _mediator.Send(new UpdateProductCommand(id, productForCreationDto));

        return NoContent();
    }
    
    /// <summary>
    /// Deletes a product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("products/{id}")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
    
    /// <summary>
    /// Gets all available brands
    /// </summary>
    /// <returns>Brands</returns>
    [HttpGet("brands")]
    [ProducesResponseType(typeof(IList<BrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _mediator.Send(new GetAllBrandsQuery());
        return Ok(brands);
    }
    
    /// <summary>
    /// Gets all available types of products
    /// </summary>
    /// <returns>Types</returns>
    [HttpGet("types")]
    [ProducesResponseType(typeof(IList<TypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductTypes()
    {
        var types = await _mediator.Send(new GetAllTypesQuery());
        return Ok(types);
    }
}