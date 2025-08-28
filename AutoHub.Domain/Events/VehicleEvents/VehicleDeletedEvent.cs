namespace VehicleAutoHub.Domain.Events.VehicleEvents;

public record VehicleDeletedEvent(Vehicle Vehicle): IDomainEvent;