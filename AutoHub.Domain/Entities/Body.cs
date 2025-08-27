namespace VehicleAutoHub.Domain.Entities;
public class Body: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS
    
    // Vehicle & Body -> ONE_TO_MANY
    public ICollection<Vehicle> VehiclesCollection { get; private set; } = new List<Vehicle>();

    private Body() { }

    public Body(string name)
    {
        Name = name;
    }
    
    #region Create Body
    public static Body CreateBody(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        var body = new Body { Name = name };
        
        return body;
    }
    #endregion

    #region Update Body
    public void UpdateBody(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name;
    }
    #endregion

    #region Soft Delete Body
    public void SoftDeleteBody()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted Body
    public void RestoreDeletedBody()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}