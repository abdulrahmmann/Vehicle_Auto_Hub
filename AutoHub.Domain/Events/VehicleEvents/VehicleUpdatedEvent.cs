namespace VehicleAutoHub.Domain.Events.VehicleEvents;

public record VehicleUpdatedEvent(Vehicle Vehicle): IDomainEvent;