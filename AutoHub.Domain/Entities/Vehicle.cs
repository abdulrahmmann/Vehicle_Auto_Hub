using VehicleAutoHub.Domain.Events.VehicleEvents;
using VehicleAutoHub.Domain.IdentityEntities;

namespace VehicleAutoHub.Domain.Entities;

public class Vehicle: Aggregate<int>
{
    public string Name { get; private set; } = null!;

    public short Year { get; private set; }
    
    public string Engine { get; private set; } = null!;

    public short EngineCc { get; private set; }

    public byte EngineCylinders { get; private set; }

    public decimal EngineLiterDisplay { get; private set; }

    public byte NumDoors { get; private set; }
    
    public string Description { get; private set; } = null!;
    
    // FOREIGN KEYS && NAVIGATIONS

    // Vehicle & Body -> ONE_TO_MANY
    public int BodyId { get; private set; }
    public Body Body { get; private set; } = null!;

    
    // Vehicle & DriveType -> ONE_TO_MANY
    public int DriveTypeId { get; private set; }
    public DriveType DriveType { get; private set; } = null!;

    
    // Vehicle & FuelType -> ONE_TO_MANY
    public int FuelTypeId { get; private set; }
    public FuelType FuelType { get; private set; } = null!;

    
    // Vehicle & Make -> ONE_TO_MANY 
    public int MakeId { get; private set; }
    public Make Make { get; private set; } = null!;

    
    // Vehicle & Model -> ONE_TO_MANY  
    public int ModelId { get; private set; }
    public Model Model { get; private set; } = null!;

    
    // Vehicle & SubModel -> ONE_TO_MANY 
    public int SubModelId { get; private set; }
    public SubModel SubModel { get; private set; } = null!;
    
    
    // Vehicle & Colors -> ONE_TO_MANY 
    public int ColorId { get; private set; }
    public Color Color { get; private set; } = null!;
    
    
    // Vehicle & Category -> ONE_TO_MANY 
    public int CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;
    
    // Vehicle & TransmissionType -> ONE_TO_MANY 
    public int TransmissionTypeId { get; private set; }
    public TransmissionType  TransmissionType { get; private set; } =  null!;
    
    
    // Vehicle & User -> ONE_TO_MANY 
    public int UserId { get; private set; }
    public ApplicationUser User { get; private set; } = null!;
    
    public ICollection<VehicleFeature> VehicleFeatures { get; private set; } = new List<VehicleFeature>();
    
    public List<string> VehicleImages { get; private set; } = [];

    
    #region Create Vehicle
    public static Vehicle CreateVehicle(
        string name, short year, string engine, short engineCc, byte engineCylinders,
        decimal engineLiterDisplay, byte numDoors, string description,  int bodyId, int driveTypeId, int fuelTypeId,
        int makeId, int modelId,int subModelId, int colorId, int categoryId, int transmissionTypeId, int userId,
        ICollection<VehicleFeature>? vehicleFeatures, List<string>? vehicleImages) 
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(engine);
        ArgumentException.ThrowIfNullOrEmpty(description);
        
        var vehicle = new Vehicle
        {
            Name = name,
            Year = year,
            Engine = engine,
            EngineCc = engineCc,
            EngineCylinders = engineCylinders,
            EngineLiterDisplay = engineLiterDisplay,
            NumDoors = numDoors,
            Description = description,
            BodyId = bodyId,
            DriveTypeId = driveTypeId,
            FuelTypeId = fuelTypeId,
            MakeId = makeId,
            ModelId = modelId,
            SubModelId = subModelId,
            ColorId = colorId,
            CategoryId = categoryId,
            TransmissionTypeId = transmissionTypeId,
            UserId = userId,
            VehicleFeatures = vehicleFeatures ?? new List<VehicleFeature>(),
            VehicleImages = vehicleImages ?? new List<string>()
        };

        vehicle.AddDomainEvent(new VehicleCreatedEvent(vehicle));
        
        return vehicle;
    }
    #endregion
    
    
    #region Update Vehicle
    public void UpdateVehicle(
        string? name = null,
        short? year = null,
        string? engine = null,
        short? engineCc = null,
        byte? engineCylinders = null,
        decimal? engineLiterDisplay = null,
        byte? numDoors = null,
        string? description = null,
        int? bodyId = null,
        int? driveTypeId = null,
        int? fuelTypeId = null,
        int? makeId = null,
        int? modelId = null,
        int? subModelId = null,
        int? colorId = null,
        int? categoryId = null,
        int? transmissionTypeId = null
    )
    {
        if (!string.IsNullOrWhiteSpace(name)) Name = name;
        if (year.HasValue) Year = year.Value;
        if (!string.IsNullOrWhiteSpace(engine)) Engine = engine;
        if (engineCc.HasValue) EngineCc = engineCc.Value;
        if (engineCylinders.HasValue) EngineCylinders = engineCylinders.Value;
        if (engineLiterDisplay.HasValue) EngineLiterDisplay = engineLiterDisplay.Value;
        if (numDoors.HasValue) NumDoors = numDoors.Value;
        if (!string.IsNullOrWhiteSpace(description)) Description = description;

        if (bodyId.HasValue) BodyId = bodyId.Value;
        if (driveTypeId.HasValue) DriveTypeId = driveTypeId.Value;
        if (fuelTypeId.HasValue) FuelTypeId = fuelTypeId.Value;
        if (makeId.HasValue) MakeId = makeId.Value;
        if (modelId.HasValue) ModelId = modelId.Value;
        if (subModelId.HasValue) SubModelId = subModelId.Value;
        if (colorId.HasValue) ColorId = colorId.Value;
        if (categoryId.HasValue) CategoryId = categoryId.Value;
        if (transmissionTypeId.HasValue) TransmissionTypeId = transmissionTypeId.Value;

        AddDomainEvent(new VehicleUpdatedEvent(this));
    }
    #endregion
    
    
    #region Soft Delete Vehicle
    public void SoftDeleteVehicle()
    {
        if (this.IsDeleted) return; // false
        
        this.IsDeleted = !this.IsDeleted;
        AddDomainEvent(new VehicleDeletedEvent(this));
    }
    #endregion
    
    
    #region Restore Deleted Vehicle
    public void RestoreDeletedVehicle()
    {
        if (!this.IsDeleted) return; // true
        
        this.IsDeleted = !this.IsDeleted;
        AddDomainEvent(new VehicleRestoredEvent(this));
    }
    #endregion
}