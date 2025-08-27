namespace VehicleAutoHub.Domain.Entities;

public class Color: Aggregate<int>
{
    public string Name { get; private set; } = null!;
    
    public string Code { get; private set; } = null!;
    
    public string FinishType { get;  set; } = null!;
    
    public bool IsActive { get; private set; } 
    
    // Vehicle & Color -> ONE_TO_MANY
    // public ICollection<Vehicle> VehiclesCollection { get; private set; }  = new List<Vehicle>();

    private Color() { }

    public Color(string name, string code, string finishType, bool isActive)
    {
        Name = name;
        Code = code;
        FinishType = finishType;
        IsActive = isActive;
    }

    #region Create Color
    public static Color CreateColor(string name, string code, string finishType, bool isActive)
    {
        ArgumentException. ThrowIfNullOrEmpty(name);
        ArgumentException. ThrowIfNullOrEmpty(code);
        ArgumentException. ThrowIfNullOrEmpty(finishType);

        var color = new Color { Name = name, Code = code, FinishType = finishType, IsActive = isActive };
        
        return color;
    }
    #endregion
    
    #region Update Color
    public void UpdateColor(string? name, string? code, string? finishType, bool? isActive)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(code);
        ArgumentException.ThrowIfNullOrEmpty(finishType);
        
        Name = name ?? Name;
        Code = code ?? Code;
        FinishType = finishType ?? FinishType;
        IsActive = isActive ?? IsActive;
    }
    #endregion
    
    #region Soft Delete Color
    public void SoftDeleteColor()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
    
    #region Restore Deleted Color
    public void RestoreDeletedColor()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
    }
    #endregion
}