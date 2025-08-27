using VehicleAutoHub.Domain.Common;
using VehicleAutoHub.Domain.DomainEvents;

namespace VehicleAutoHub.Domain.Aggregate;

public interface IAggregate<T> : IAggregate, IEntity<T>
{
     
}

public interface IAggregate: IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    
    IDomainEvent[] ClearDomainEvents();
}