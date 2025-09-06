namespace VehicleAutoHub.Infrastructure.UOF;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    public void SaveChanges() => dbContext.SaveChanges();

    public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();

    public void Dispose() => dbContext.Dispose();
}