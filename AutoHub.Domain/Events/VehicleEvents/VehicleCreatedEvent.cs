namespace VehicleAutoHub.Domain.Events.VehicleEvents;

public record VehicleCreatedEvent(Vehicle Vehicle): IDomainEvent;