﻿using VehicleAutoHub.Domain.Common;
using VehicleAutoHub.Domain.DomainEvents;

namespace VehicleAutoHub.Domain.Aggregate;

public abstract class Aggregate<T>: Entity<T>, IAggregate<T>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    
    public IDomainEvent[] ClearDomainEvents()
    {
        var dequeuedEvents = _domainEvents.ToArray();
        _domainEvents.Clear();
        return dequeuedEvents;
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}