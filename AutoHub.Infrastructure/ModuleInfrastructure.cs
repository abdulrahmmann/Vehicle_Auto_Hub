namespace VehicleAutoHub.Infrastructure;

public static class ModuleInfrastructure
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // REGISTER INTERCEPTORS
        services.AddScoped<ISaveChangesInterceptor, AuditSaveChangesInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        
        // REGISTER DB CONTEXT
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetService<ISaveChangesInterceptor>()!);
            
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
        // REGISTER IDENTITY
        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()

            .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, int>>()
            .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, int>>();
        
        
        // REGISTER UNIT OF WORK    
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // REGISTER GENERIC REPOSITORY  
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        // REGISTER REPOSITORIES  
        
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        InitializeDatabase(app).GetAwaiter().GetResult();

        return app;
    }
    
    private static async Task InitializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        await context.Database.MigrateAsync();

    }
}