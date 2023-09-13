using System.Net;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
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
    
    [HttpGet("products")]
    [ProducesResponseType(typeof(IList<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }
    
    [HttpGet("products/{id:string}", Name = "ProductById")]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await _mediator.Send(new GetProductQuery(id));
        return Ok(product);
    }
    
    [HttpGet("products/[action]/{name:string}", Name = "ProductsByName")]
    [ProducesResponseType(typeof(IList<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByName(string name)
    {
        var products = await _mediator.Send(new GetProductByNameQuery(name));
        return Ok(products);
    }
    
    [HttpGet("products/[action]/{brand:string}", Name = "ProductsByBrand")]
    [ProducesResponseType(typeof(IList<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByBrand(string brand)
    {
        var products = await _mediator.Send(new GetProductByBrandQuery(brand));
        return Ok(products);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto productForCreationDto)
    {
        var product = await _mediator.Send(new CreateProductCommand(productForCreationDto));

        return CreatedAtRoute("ProductById", new { id = product.Id }, product);
    }
    
    [HttpPut("products/{id:string}")]
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
    
    [HttpDelete("products/{id:string}")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
    
    [HttpGet("brands")]
    [ProducesResponseType(typeof(IList<BrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _mediator.Send(new GetAllBrandsQuery());
        return Ok(brands);
    }
    
    [HttpGet("types")]
    [ProducesResponseType(typeof(IList<TypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductTypes()
    {
        var types = await _mediator.Send(new GetAllTypesQuery());
        return Ok(types);
    }
}