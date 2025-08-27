namespace VehicleAutoHub.Domain.Entities;
public class Body: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS
    
    // Vehicle & Body -> ONE_TO_MANY
    // public ICollection<Vehicle> VehiclesCollection { get; private set; } = new List<Vehicle>();

    private Body() { }

    public Body(string name)
    {
        Name = name;
    }
    
    #region Create Body
    public static void CreateBody(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        var body = new Body { Name = name };
        
        body.AddDomainEvent(new BodyCreatedEvent(body));
    }
    #endregion

    #region Update Body
    public void UpdateBody(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name;

        if (Name != name)
        {
            AddDomainEvent(new BodyNameChangedEvent(this));
        }
    }
    #endregion

    #region Soft Delete Body
    public void SoftDeleteBody()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
        AddDomainEvent(new BodyDeletedEvent(this));
    }
    #endregion
    
    #region Restore Deleted Body
    public void RestoreDeletedBody()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
        AddDomainEvent(new BodyRestoredEvent(this));
    }
    #endregion
}