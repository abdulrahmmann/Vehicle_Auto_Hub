namespace VehicleAutoHub.Infrastructure.UOF;

public interface IUnitOfWork: IDisposable
{
    void SaveChanges();
    
    Task SaveChangesAsync();
}