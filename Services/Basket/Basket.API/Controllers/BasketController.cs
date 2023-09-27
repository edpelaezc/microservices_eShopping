using System.Net;
using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public class BasketController : ApiController
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Gets the basket for a given user name.
    /// </summary>
    /// <returns>Shopping cart for the current user.</returns>
    [HttpGet("baskets/{UserName}", Name = "BasketByUserName")]
    [ProducesResponseType(typeof(ShoppingCartDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBasket(string UserName)
    {
        var basket = await _mediator.Send(new GetBasketQuery(UserName));
        return Ok(basket);
    }
    
    /// <summary>
    /// Creates a new instance of shopping cart for the given user name.
    /// </summary>
    /// <param name="createShoppingCartDto">Object to create/update shopping cart</param>
    /// <returns>Shopping cart</returns>
    [HttpPost("baskets")]
    [ProducesResponseType(typeof(ShoppingCartDto), (int) HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateBasket([FromBody] ShoppingCartDto createShoppingCartDto)
    {
        var basket = await _mediator.Send(new CreateBasketCommand(createShoppingCartDto));

        return CreatedAtRoute("BasketByUserName", new { userName = basket.UserName }, basket);
    }
    
    /// <summary>
    /// Deletes the basket for the given user name.
    /// </summary>
    /// <param name="UserName">User name that owns the shopping cart</param>
    /// <returns>no content</returns>
    [HttpDelete("baskets/{UserName}")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> DeleteBasket(string UserName)
    {
        await _mediator.Send(new DeleteBasketCommand(UserName));
        return NoContent();
    }
}