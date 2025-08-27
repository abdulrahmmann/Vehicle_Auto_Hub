namespace VehicleAutoHub.Domain.Entities;
public class Body: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS
    
    // Vehicle & Body -> ONE_TO_MANY
    // public ICollection<Vehicle> VehiclesCollection { get; private set; } = new List<Vehicle>();

    public static void CreateBody(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        var body = new Body { Name = name };
        
        body.AddDomainEvent(new BodyCreatedEvent(body));
    }

    public void UpdateBody(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name;

        if (Name != name)
        {
            AddDomainEvent(new BodyNameChangedEvent(this));
        }
    }

    public void SoftDeleteBody()
    {
        if (!this.IsDeleted) // false
        {
            this.IsDeleted = !this.IsDeleted;
            AddDomainEvent(new BodyDeletedEvent(this));
        }
    }
    
    public void RestoreDeletedBody()
    {
        if (this.IsDeleted) // true
        {
            this.IsDeleted = !this.IsDeleted;
            AddDomainEvent(new BodyDeletedEvent(this));
        }
    }
}