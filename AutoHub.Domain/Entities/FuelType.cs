namespace VehicleAutoHub.Domain.Entities;

public class FuelType: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS
    
    // Vehicle & FuelType -> ONE_TO_MANY
    // public ICollection<Vehicle> VehiclesCollection { get; private set; } = new List<Vehicle>();

    private FuelType() { }

    public FuelType(string name)
    {
        Name = name;
    }
    
    #region Create FuelType
    public static FuelType CreateFuelType(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var fuelType = new FuelType { Name = name };
        
        return fuelType;
    }
    #endregion
    
    #region Update FuelType
    public void UpdateFuelType(string? name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name ?? Name;
    }
    #endregion
    
    #region Soft Delete FuelType
    public void SoftDeleteFuelType()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted FuelType
    public void RestoreDeletedFuelType()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}