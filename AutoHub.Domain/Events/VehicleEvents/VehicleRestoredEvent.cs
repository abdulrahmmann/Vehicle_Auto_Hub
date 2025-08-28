namespace VehicleAutoHub.Domain.Events.VehicleEvents;

public record VehicleRestoredEvent(Vehicle Vehicle): IDomainEvent;