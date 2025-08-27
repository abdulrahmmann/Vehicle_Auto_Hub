namespace VehicleAutoHub.Domain.Entities;

public class SubModel: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS
    
    // Models & SubModels -> ONE_TO_MANY 
    public int ModelId { get; private set; }
    public Model Model { get; private set; } = null!;
    
    // Vehicle & SubModel -> ONE_TO_MANY
    // public ICollection<Vehicle> VehiclesCollection { get; private set; }  = new List<Vehicle>();

    private SubModel() { }

    public SubModel(string name)
    {
        Name = name;
    }

    public SubModel(string name, int modelId)
    {
        Name = name;
        ModelId = modelId;
    }
    
    #region Create SubModel
    public static SubModel CreateSubModel(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var subModel = new SubModel { Name = name };
        
        return subModel;
    }
    #endregion
    
    #region Update SubModel
    public void UpdateSubModel(string? name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name ?? Name;
    }
    #endregion
    
    #region Soft Delete SubModel
    public void SoftDeleteSubModel()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted SubModel
    public void RestoreDeletedSubModel()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}