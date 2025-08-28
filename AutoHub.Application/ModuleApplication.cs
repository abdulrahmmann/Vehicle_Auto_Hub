namespace VehicleAutoHub.Application;

public static class ModuleApplication
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Mediator
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // Register JWT Services
        services.AddScoped<IGenerateTokenService, GenerateTokenService>();
        services.AddScoped<IGenerateRefreshTokenService, GenerateRefreshTokenService>();
        services.AddScoped<IGeneratePrincipalFromJwtTokenService, GeneratePrincipalFromJwtTokenService>();
        
        // Register FLUENT VALIDATION
        // services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
        
        return services;
    }
}