namespace VehicleAutoHub.Domain.Events;

public record VehicleRestoredEvent(Vehicle Vehicle): IDomainEvent;