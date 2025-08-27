namespace VehicleAutoHub.Domain.Entities;

public class Make: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS
    
    // Makes & Model -> ONE_TO_MANY 
    public ICollection<Model> ModelsCollection { get; private set; } = new List<Model>();
    
    // Vehicle & Makes -> ONE_TO_MANY
    public ICollection<Vehicle> VehiclesCollection { get; private set; }  = new List<Vehicle>();

    private Make() { }

    public Make(string name)
    {
        Name = name;
    }
    
    #region Create Make
    public static Make CreateMake(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var make = new Make { Name = name };
        
        return make;
    }
    #endregion
    
    #region Update Make
    public void UpdateMake(string? name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name ?? Name;
    }
    #endregion
    
    #region Soft Delete Make
    public void SoftDeleteMake()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted Make
    public void RestoreDeletedMake()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}