namespace VehicleAutoHub.Infrastructure.UOF;

public class UnitOfWork: IUnitOfWork
{
    #region Instance Fields
    private readonly ApplicationDbContext  _dbContext;
    private readonly Dictionary<Type, object> _repositories;
    #endregion
    
    public ApplicationDbContext dbContext { get; } 
    
    public IMakesRepository GetMakesRepository { get; }

    #region Constructor
    public UnitOfWork(ApplicationDbContext dbContext, IMakesRepository getMakesRepository)
    {
        _dbContext = dbContext;
        this.dbContext = dbContext;
        GetMakesRepository = getMakesRepository;
        _repositories = new Dictionary<Type, object>();
    }
    #endregion
    
    public IGenericRepository<T> GetRepository<T>() where T : class
    {
        var type = typeof(T);
        
        if (!_repositories.ContainsKey(type))
        {
            var repoInstance = new GenericRepository<T>(_dbContext);
            _repositories[type] = repoInstance;
        }

        return (IGenericRepository<T>)_repositories[type];
    }

    public void SaveChanges() => dbContext.SaveChanges();

    public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();

    public void Dispose() => dbContext.Dispose();
}