using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Application.Features.Products.Commands;

public interface IEventStore
{
    Task SaveEventAsync(IDomainEvent domainEvent, Guid aggregateId);

    Task<IReadOnlyList<StoredEvent>> GetEventsAsync(Guid aggregateId);
}
