namespace VehicleAutoHub.Domain.Entities;

public class Model: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS
    
    // Makes & Model -> ONE_TO_MANY 
    public int MakeId { get; private set; }
    
    public Make Make { get; private set; } = null!;
    
    // Model & SubModels -> ONE_TO_MANY 
    public ICollection<SubModel> SubModelsCollection { get; private set; } = new  List<SubModel>();
    
    // Vehicle & Model -> ONE_TO_MANY
    public ICollection<Vehicle> VehiclesCollection { get; private set; }  = new List<Vehicle>();

    private Model() { }

    public Model(string name)
    {
        Name = name;
    }

    public Model(string name, int makeId)
    {
        Name = name;
        MakeId = makeId;
    }
    
    #region Create Model
    public static Model CreateModel(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var model = new Model { Name = name };
        
        return model;
    }
    #endregion
    
    #region Update Model
    public void UpdateModel(string? name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name ?? Name;
    }
    #endregion
    
    #region Soft Delete Model
    public void SoftDeleteModel()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted Model
    public void RestoreDeletedModel()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}