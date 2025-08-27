namespace VehicleAutoHub.Domain.Events;

public record VehicleUpdatedEvent(Vehicle Vehicle): IDomainEvent;