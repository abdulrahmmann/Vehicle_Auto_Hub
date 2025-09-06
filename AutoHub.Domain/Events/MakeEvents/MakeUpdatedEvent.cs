namespace VehicleAutoHub.Domain.Events.MakeEvents;

public record MakeUpdatedEvent(Make Make): IDomainEvent;