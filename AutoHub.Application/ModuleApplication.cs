namespace VehicleAutoHub.Application;

public static class ModuleApplication
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Mediator
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // Register JWT Services
        
        
        // Register FLUENT VALIDATION
        // services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
        
        return services;
    }
}