namespace VehicleAutoHub.Domain.Entities;

public class DriveType: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS
    
    // Vehicle & DriveType -> ONE_TO_MANY
    public ICollection<Vehicle> VehiclesCollection { get; private set; } = new List<Vehicle>();

    private DriveType() { }

    public DriveType(string name)
    {
        Name = name;
    }
    
    #region Create DriveType
    public static DriveType CreateDriveType(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var driveType = new DriveType { Name = name };
        
        return driveType;
    }
    #endregion
    
    #region Update DriveType
    public void UpdateDriveType(string? name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name ?? Name;
    }
    #endregion
    
    #region Soft Delete DriveType
    public void SoftDeleteDriveType()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted DriveType
    public void RestoreDeletedDriveType()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}