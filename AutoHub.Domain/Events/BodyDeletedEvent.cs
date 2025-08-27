namespace VehicleAutoHub.Domain.Events;

public record BodyDeletedEvent(Body Body): IDomainEvent;