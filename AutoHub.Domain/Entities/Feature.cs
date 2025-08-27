namespace VehicleAutoHub.Domain.Entities;

public class Feature: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // public ICollection<VehicleFeature> VehicleFeatures { get; private set; } = new List<VehicleFeature>();

    private Feature() { }

    public Feature(string name)
    {
        Name = name;
    }
    
    #region Create Feature
    public static Feature CreateFeature(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var feature = new Feature { Name = name };
        
        return feature;
    }
    #endregion
    
    #region Update Feature
    public void UpdateFeature(string? name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name ?? Name;
    }
    #endregion
    
    #region Soft Delete Feature
    public void SoftDeleteFeature()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted Feature
    public void RestoreDeletedFeature()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}