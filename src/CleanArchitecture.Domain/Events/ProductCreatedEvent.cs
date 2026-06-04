namespace CleanArchitecture.Domain.Events;

public record ProductCreatedEvent(Guid AggregateId, string Name, decimal Price) : DomainEventBase;
