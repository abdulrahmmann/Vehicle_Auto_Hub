namespace VehicleAutoHub.Domain.Events;

public record VehicleDeletedEvent(Vehicle Vehicle): IDomainEvent;