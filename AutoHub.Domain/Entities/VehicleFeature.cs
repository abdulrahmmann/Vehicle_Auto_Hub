﻿namespace VehicleAutoHub.Domain.Entities;

public class VehicleFeature
{
    public Vehicle Vehicle { get; private set; } = null!;

    public int VehicleId { get; private set; }
    public int FeatureId { get; private set; }
    
    public Feature Feature { get; private set; } = null!;

    private VehicleFeature() { }
    
    public static VehicleFeature CreateVehicleFeature(int vehicleId, int featureId)
    {
        return new VehicleFeature
        {
            VehicleId = vehicleId,
            FeatureId = featureId,
        };
    }
}