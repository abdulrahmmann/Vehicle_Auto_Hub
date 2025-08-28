namespace VehicleAutoHub.Infrastructure.Interceptors;

public class AuditSaveChangesInterceptor: SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateEntities(eventData.Context);
            
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateEntities(DbContext? context)
    {
        if (context is null) return;

        foreach (var entity in context.ChangeTracker.Entries<IEntity>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedBy = "Abdulrahman_Mustafa";
                entity.Entity.CreatedAt = DateTime.UtcNow;
            }
            
            if (entity.State is EntityState.Added or EntityState.Modified)
            {
                entity.Entity.LastModifiedBy = "Abdulrahman_Mustafa";
                entity.Entity.LastModified = DateTime.UtcNow;
            }
        }
    }
}