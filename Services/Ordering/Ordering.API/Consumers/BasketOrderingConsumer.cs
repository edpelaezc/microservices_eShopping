using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Ordering.Application.Commands;
using Ordering.Application.Responses;
using IMediator = MediatR.IMediator;

namespace Ordering.API.Consumers;

public class BasketOrderingConsumer : IConsumer<BasketCheckoutEvent>
{
    readonly ILogger<BasketOrderingConsumer> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BasketOrderingConsumer(ILogger<BasketOrderingConsumer> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        using var scope =  
            _logger.BeginScope("Consuming Basket Checkout Event for [CRID]: {correlationId}",
            context.Message.CorrelationId);
        
        var dto = _mapper.Map<OrderForCreationDto>(context.Message);
        var order = await _mediator.Send(new CheckoutOrderCommand(dto));
        _logger.LogInformation($"Basket checkout event completed for [CRID]: {context.Message.CorrelationId}, order ID: {order.Id}");
    }
}