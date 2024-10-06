namespace LuftbornCodeTest;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected DbSet<TEntity> dbSet;
    private readonly ApplicationDbContext _context;
    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> Get() => await dbSet.ToListAsync();
    public virtual async Task<TEntity> Get(int id) => await
                                          dbSet.FirstOrDefaultAsync(e => e.Id == id) ?? Activator.CreateInstance<TEntity>();

    public virtual async Task Add(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException($"{nameof(TEntity)} was not provided.");

        await dbSet.AddAsync(entity);
        await SaveChangesAsync();
    }
    public virtual async Task Add(IEnumerable<TEntity> entities)
    {
        await dbSet.AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entity)
    {
        TEntity? entityFromDb = await Get(entity.Id);
        if (entityFromDb == null)
            throw new ArgumentNullException($"{nameof(TEntity)} was not found in DB");

        await Task.Run(() => dbSet.Update(entity));

        await SaveChangesAsync();
    }

    public virtual async Task Remove(int id)
    {
        TEntity? entityFromDb = await Get(id);
        if (entityFromDb == null)
            throw new ArgumentNullException($"{nameof(TEntity)} was not found in DB");

        await Task.Run(() => dbSet.Remove(entityFromDb));
        await SaveChangesAsync();
    }
    public virtual async Task Remove(TEntity entity)
    {
        TEntity? entityFromDb = await Get(entity.Id);
        if (entityFromDb == null)
            throw new ArgumentNullException($"{nameof(TEntity)} was not found in DB");

        await Task.Run(() => dbSet.Remove(entity));
        await SaveChangesAsync();
    }
    public virtual async Task Remove(IEnumerable<TEntity> entities)
    {
        if (entities == null || !entities.Any())
            throw new ArgumentNullException($"{nameof(TEntity)} was not provided.");

        await Task.Run(() => dbSet.RemoveRange(entities));
        await SaveChangesAsync();
    }

    protected async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}