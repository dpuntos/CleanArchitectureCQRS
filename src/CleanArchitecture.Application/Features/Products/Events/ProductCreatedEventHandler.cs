using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Products.Events;

public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
{
    private readonly ILogger<ProductCreatedEventHandler> _logger;

    public ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
        => _logger = logger;

    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Product created. AggregateId: {AggregateId}, Name: {Name}, Price: {Price}, OccurredOn: {OccurredOn}",
            notification.AggregateId,
            notification.Name,
            notification.Price,
            notification.OccurredOn);

        return Task.CompletedTask;
    }
}
