namespace LuftbornCodeTest;

    public interface IBaseRepository<TEntity>
    {
    Task Add(IEnumerable<TEntity> entities);
    Task Add(TEntity entity);

    Task<IEnumerable<TEntity>> Get();
    Task<TEntity> Get(int id);

    Task Remove(IEnumerable<TEntity> entities);
    Task Remove(int id);
    Task Remove(TEntity entity);

    Task Update(TEntity entity);
}
