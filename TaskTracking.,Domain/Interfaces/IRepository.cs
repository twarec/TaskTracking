namespace TaskTracking.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public IQueryable<TEntity> GetAll();
    public Task<TEntity> GetByIdAsync(object id);

    public Task<TEntity> CreateAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task RemoveAsync(TEntity entity);
}
