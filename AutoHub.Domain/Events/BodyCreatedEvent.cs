namespace VehicleAutoHub.Domain.Events;

public record BodyCreatedEvent(Body Body): IDomainEvent;