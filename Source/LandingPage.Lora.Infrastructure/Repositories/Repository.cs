using System.Linq.Expressions;
using LandingPage.Lora.Domain.Entities.Interfaces;
using LandingPage.Lora.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LandingPage.Lora.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly LoraDbContext _dbContext;
    
    public Repository(LoraDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public virtual void Add(TEntity entity)
    {
        if (entity is IHasCreatedAt && (entity as IHasCreatedAt).CreatedAt == DateTime.MinValue)
            (entity as IHasCreatedAt).CreatedAt = DateTime.UtcNow;
        _dbContext.Add(entity);
    }

    public virtual void AddMany(IEnumerable<TEntity> entities)
    {
        if (typeof(IHasCreatedAt).IsAssignableFrom(typeof(TEntity)))
        {
            foreach(TEntity entity in entities)
                if ((entity as IHasCreatedAt).CreatedAt == DateTime.MinValue)
                    (entity as IHasCreatedAt).CreatedAt = DateTime.UtcNow;
        }
        _dbContext.AddRange(entities);
    }

    public virtual IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> predicate = null)
    {
        if (predicate != null)
        {
            return _dbContext
                .Set<TEntity>()
                .Where(predicate)
                .ToList();
        }

        return _dbContext
                .Set<TEntity>()
                .ToList();
    }
    
    public virtual async Task<IEnumerable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        if (predicate != null)
        {
            return await _dbContext
                .Set<TEntity>()
                .Where(predicate)
                .ToListAsync();
        }

        return await _dbContext
                .Set<TEntity>()
                .ToListAsync();
    }

    public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
    {
        if (predicate != null)
        {
            return _dbContext
                .Set<TEntity>()
                .Where(predicate)
                .Count();
        }

        return _dbContext
                .Set<TEntity>()
                .Count();
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        if (predicate != null)
        {
            return await _dbContext
                .Set<TEntity>()
                .Where(predicate)
                .CountAsync();
        }

        return await _dbContext
                .Set<TEntity>()
                .CountAsync();
    }

    public virtual async Task<TEntity> FindAsync<TKey>(TKey id)
    {
        return await _dbContext
            .Set<TEntity>()
            .FindAsync(id);
    }

    public virtual TEntity Find<TKey>(TKey id)
    {
        return _dbContext
            .Set<TEntity>()
            .Find(id);
    }

    public void Remove(TEntity entity)
    {
        _dbContext
            .Set<TEntity>()
            .Remove(entity);
    }

    public void RemoveMany(IEnumerable<TEntity> entities)
    {
        _dbContext
            .Set<TEntity>()
            .RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        if (entity is IHasUpdatedAt && !(entity as IHasUpdatedAt).UpdatedAt.HasValue)
            (entity as IHasUpdatedAt).UpdatedAt = DateTime.UtcNow;

        _dbContext
            .Set<TEntity>()
            .Update(entity);
    }

    public void UpdateMany(IEnumerable<TEntity> entities)
    {
        if (typeof(IHasUpdatedAt).IsAssignableFrom(typeof(TEntity)))
        {
            foreach(TEntity entity in entities)
                if (!(entity as IHasUpdatedAt).UpdatedAt.HasValue)
                    (entity as IHasUpdatedAt).UpdatedAt = DateTime.UtcNow;
        }

        _dbContext
            .Set<TEntity>()
            .UpdateRange(entities);
    }

    public virtual async Task<bool> ExistsAsync<TKey>(TKey id)
    {
        TEntity exists = await _dbContext
            .Set<TEntity>()
            .FindAsync(id);

        return exists is not null;
    }
}