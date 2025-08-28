namespace VehicleAutoHub.Application.Services.GeneratePrincipalJwtToken;

public interface IGeneratePrincipalFromJwtTokenService
{
    ClaimsPrincipal GetPrincipalFromJwtToken(string token);
}