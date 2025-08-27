namespace VehicleAutoHub.Domain.Events;

public record VehicleCreatedEvent(Vehicle Vehicle): IDomainEvent;