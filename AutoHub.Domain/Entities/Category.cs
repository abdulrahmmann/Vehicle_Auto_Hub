namespace VehicleAutoHub.Domain.Entities;

public class Category: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    public string Description { get; private set; } = null!;

    
    // Vehicle & Category -> ONE_TO_MANY
    // public ICollection<Vehicle> VehiclesCollection { get; private set; }  = new List<Vehicle>();

    private Category() {}
    
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    #region Create Category
    public static Category CreateCategory(string name, string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);
        
        var category = new Category { Name = name,  Description = description };
        
        return category;
    }
    #endregion

    #region Update Category
    public void UpdateCategory(string name, string? description)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name;
        Description = description ?? Description;
    }
    #endregion

    #region Soft Delete Category
    public void SoftDeleteCategory()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted Category
    public void RestoreDeletedCategory()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}
