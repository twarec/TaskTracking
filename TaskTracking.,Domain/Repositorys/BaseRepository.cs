using Microsoft.EntityFrameworkCore;
using TaskTracking.Domain.Exceptions;
using TaskTracking.Domain.Interfaces;

namespace TaskTracking.Domain.Repositorys;

public class BaseRepository<TEntity>(DbContext context) : IRepository<TEntity> where TEntity : class
{

    protected DbSet<TEntity> set = context.Set<TEntity>();

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Added;
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> GetByIdAsync(object id)
    {
        return await set.FindAsync(id)
            ?? throw new NotFoundException();
    }

    public IQueryable<TEntity> GetAll()
    {
        return set;
    }

    public async Task RemoveAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Deleted;
        await context.SaveChangesAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return entity;
    }
}
