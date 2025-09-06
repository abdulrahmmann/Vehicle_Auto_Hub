namespace VehicleAutoHub.Domain.IRepository;

public interface IMakesRepository:  IGenericRepository<Make>
{
    #region POST 
    Task CreateMake(Make make);
    #endregion
    
    #region PUT 
    Task UpdateMake(int id, Make make);
    #endregion
    
    #region DELETE 
    Task SoftDeleteMakeById(int id);
    
    Task RestoreMakeById(int id);
    #endregion
}