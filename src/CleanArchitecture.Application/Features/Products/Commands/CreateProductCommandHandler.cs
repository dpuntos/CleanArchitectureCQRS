using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Features.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IProductWriteRepository _repository;
    private readonly IEventStore _eventStore;
    private readonly IMediator _mediator;

    public CreateProductCommandHandler(
        IProductWriteRepository repository,
        IEventStore eventStore,
        IMediator mediator)
    {
        _repository = repository;
        _eventStore = eventStore;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // 1) Persist current state
        var product = new Product(request.Name, request.Price);
        await _repository.AddAsync(product);

        // 2) Append the immutable domain event (Event Sourcing)
        var domainEvent = new ProductCreatedEvent(Guid.NewGuid(), product.Name, product.Price);
        await _eventStore.SaveEventAsync(domainEvent, domainEvent.AggregateId);

        // 3) Publish to subscribed notification handlers
        await _mediator.Publish(domainEvent, cancellationToken);

        return Unit.Value;
    }
}
