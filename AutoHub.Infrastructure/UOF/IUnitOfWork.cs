namespace VehicleAutoHub.Infrastructure.UOF;

public interface IUnitOfWork: IDisposable
{
    ApplicationDbContext dbContext { get; }
    
    IMakesRepository  GetMakesRepository { get; }
    
    void SaveChanges();
    
    Task SaveChangesAsync();
}