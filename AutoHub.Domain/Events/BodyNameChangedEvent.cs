namespace VehicleAutoHub.Domain.Events;

public record BodyNameChangedEvent(Body Body): IDomainEvent;