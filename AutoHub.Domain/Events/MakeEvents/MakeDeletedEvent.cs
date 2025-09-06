namespace VehicleAutoHub.Domain.Events.MakeEvents;

public record MakeDeletedEvent(Make Make): IDomainEvent;