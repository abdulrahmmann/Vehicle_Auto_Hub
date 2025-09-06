namespace VehicleAutoHub.Infrastructure.Repository;

public class MakesRepository(ApplicationDbContext dbContext) : GenericRepository<Make>(dbContext), IMakesRepository
{
    #region Instance Fields
    private readonly ApplicationDbContext _dbContext = dbContext;
    #endregion

    public async Task CreateMake(Make make)
    {
        var makeToCreate = await _dbContext.Makes.FirstOrDefaultAsync(m => m.Name == make.Name);
        
        makeToCreate?.CreateMake(make.Name);
    }

    public async Task UpdateMake(int id, Make make)
    {
        var makeToUpdate = await _dbContext.Makes.FindAsync(id);

        makeToUpdate?.UpdateMake(make.Name);
    }

    public async Task SoftDeleteMakeById(int id)
    {
        var makeToDelete = await _dbContext.Makes.FirstOrDefaultAsync(m => m.Id == id);

        makeToDelete?.SoftDeleteMake();
    }

    public async Task RestoreMakeById(int id)
    {
        var makeToRestore = await _dbContext.Makes.IgnoreQueryFilters().FirstOrDefaultAsync(m => m.Id == id);

        makeToRestore?.RestoreDeletedMake();
    }
}