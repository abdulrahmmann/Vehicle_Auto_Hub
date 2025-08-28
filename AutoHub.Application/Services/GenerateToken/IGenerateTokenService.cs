namespace VehicleAutoHub.Application.Services.GenerateToken;

public interface IGenerateTokenService
{
    AuthenticationResponse GenerateToken(ApplicationUser user);
}