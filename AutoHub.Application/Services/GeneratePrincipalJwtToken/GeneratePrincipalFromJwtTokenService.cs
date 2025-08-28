﻿namespace VehicleAutoHub.Application.Services.GeneratePrincipalJwtToken;

public class GeneratePrincipalFromJwtTokenService: IGeneratePrincipalFromJwtTokenService
{
    private readonly IConfiguration _configuration;

    public GeneratePrincipalFromJwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ClaimsPrincipal GetPrincipalFromJwtToken(string token)
    {
        var tokenValidation = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,
            
            ValidAudience = _configuration["Jwt:Audience"],
            ValidIssuer = _configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SECRET_KEY"])),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var principal = tokenHandler.ValidateToken(token, tokenValidation, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }
        return principal;
    }
}