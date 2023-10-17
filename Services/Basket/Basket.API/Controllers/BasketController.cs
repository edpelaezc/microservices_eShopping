using System.Net;
using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public class BasketController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _transportEndpoint;
    private readonly ILogger<BasketController> _logger;

    public BasketController(IMediator mediator, IPublishEndpoint transportEndpoint, ILogger<BasketController> logger)
    {
        _mediator = mediator;
        _transportEndpoint = transportEndpoint;
        _logger = logger;
        _logger.LogInformation("CRID: []");
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
    
    [HttpPost("baskets/checkout")]
    [ProducesResponseType((int) HttpStatusCode.Accepted)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
    {
        //Get existing basket with username
        var basket = await _mediator.Send(new GetBasketQuery(basketCheckout.UserName));
        if (basket is null)
        {
            return BadRequest();
        }

        // publish basket to queue
        var message = BasketMapper.Mapper.Map<BasketCheckoutEvent>(basketCheckout);
        message.TotalPrice = basket.TotalPrice;
        await _transportEndpoint.Publish(message);
        _logger.LogInformation($"Event sent to queue, CRID [{message.CorrelationId}] - {message.CreationDate}");
        
        //remove the basket
        await _mediator.Send(new DeleteBasketCommand(basketCheckout.UserName));
        return Accepted();
    }
}