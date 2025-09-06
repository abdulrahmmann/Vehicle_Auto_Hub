namespace VehicleAutoHub.Domain.Events.MakeEvents;

public record MakeCreatedEvent(Make Make): IDomainEvent;