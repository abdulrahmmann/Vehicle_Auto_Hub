namespace VehicleAutoHub.Domain.Entities;

public class TransmissionType: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    public ICollection<Vehicle> VehiclesCollection { get; private set; } = new List<Vehicle>();

    private TransmissionType() { }

    public TransmissionType(string name)
    {
        Name = name;
    }
    
    #region Create TransmissionType
    public static TransmissionType CreateTransmissionType(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var transmissionType = new TransmissionType { Name = name };
        
        return transmissionType;
    }
    #endregion
    
    #region Update TransmissionType
    public void UpdateTransmissionType(string? name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name ?? Name;
    }
    #endregion
    
    #region Soft Delete TransmissionType
    public void SoftDeleteTransmissionType()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted TransmissionType
    public void RestoreDeletedTransmissionType()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}