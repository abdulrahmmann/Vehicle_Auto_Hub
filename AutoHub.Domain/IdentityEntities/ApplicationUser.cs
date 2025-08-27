using Microsoft.AspNetCore.Identity;

namespace VehicleAutoHub.Domain.IdentityEntities;

public class ApplicationUser: IdentityUser<int>
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; } 
    
    public bool IsDeleted { get; set; } = false;
    public ICollection<Vehicle> VehiclesCollection { get; init; } = new List<Vehicle>();
}