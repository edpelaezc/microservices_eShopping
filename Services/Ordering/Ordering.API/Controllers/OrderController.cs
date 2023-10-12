using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands;
using Ordering.Application.Queries;
using Ordering.Application.Responses;

namespace Ordering.API.Controllers;

public class OrderController : ApiController
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator, ILogger<OrderController> logger)
    {
        _mediator = mediator;
    }
    
    [HttpGet("orders/{UserName}", Name = "OrderByUserName")]
    [ProducesResponseType(typeof(IEnumerable<OrderDto>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetOrdersByUserName(string UserName)
    {
        var orders = await _mediator.Send(new GetOrderListQuery(UserName));
        return Ok(orders);
    }
    
    //Just for testing locally as it will be processed in queue
    [HttpPost("orders/checkout")]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    public async Task<ActionResult> CheckoutOrder([FromBody] OrderForCreationDto orderForCreationDto)
    {
        var order = await _mediator.Send(new CheckoutOrderCommand(orderForCreationDto));
        return CreatedAtRoute("OrderByUserName", new { UserName = order.UserName }, order);
    }
    
    [HttpPut("orders/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateOrder(int id, [FromBody] OrderDto orderDto)
    {
        if (orderDto is null)
        {
            return BadRequest("orderDto is null");
        }

        await _mediator.Send(new UpdateOrderCommand(id, orderDto));
        return NoContent();
    }
    
    [HttpDelete("orders/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        await _mediator.Send(new DeleteOrderCommand(id));
        return NoContent();
    }
}