namespace VehicleAutoHub.Domain.Events;

public record BodyRestoredEvent(Body Body): IDomainEvent;