using System.Text.Json;
using CleanArchitecture.Application.Features.Products.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using CleanArchitecture.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.EventStore;

public class EventStoreRepository : IEventStore
{
    private readonly ProductDbContext _context;

    public EventStoreRepository(ProductDbContext context) => _context = context;

    public async Task SaveEventAsync(IDomainEvent domainEvent, Guid aggregateId)
    {
        var storedEvent = new StoredEvent
        {
            Id = domainEvent.EventId,
            AggregateId = aggregateId,
            EventType = domainEvent.GetType().Name,
            Data = JsonSerializer.Serialize(domainEvent, domainEvent.GetType()),
            OccurredOn = domainEvent.OccurredOn
        };

        await _context.StoredEvents.AddAsync(storedEvent);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<StoredEvent>> GetEventsAsync(Guid aggregateId)
        => await _context.StoredEvents
            .AsNoTracking()
            .Where(e => e.AggregateId == aggregateId)
            .OrderBy(e => e.OccurredOn)
            .ToListAsync();
}
