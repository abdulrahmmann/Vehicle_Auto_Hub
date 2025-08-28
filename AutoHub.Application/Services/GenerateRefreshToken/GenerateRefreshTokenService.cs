﻿namespace VehicleAutoHub.Application.Services.GenerateRefreshToken;

public class GenerateRefreshTokenService: IGenerateRefreshTokenService
{
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];

        using var randomNumberGenerator = RandomNumberGenerator.Create();
        
        randomNumberGenerator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}