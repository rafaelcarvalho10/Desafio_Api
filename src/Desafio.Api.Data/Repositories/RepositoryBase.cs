//using Confluent.Kafka;
using Desafio.Api.Data.Context;
using Desafio.Api.Domain.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.Api.Data.Repositories
{
  public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
  {
    public readonly RepositoryDbContext _dbContext;

    protected RepositoryBase(RepositoryDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
      await _dbContext.Set<TEntity>().AddAsync(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
    }

    public virtual async Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
    {
      if (predicate != null)
      {
        var query = _dbContext.Set<TEntity>().Where(predicate);

        return await query.ToListAsync();
      }

      return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
      return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, Guid id)
    {
      if (entity == null)
        return null;

      var existing = await _dbContext.Set<TEntity>().FindAsync(id);
      if (existing == null)
        return null;

      _dbContext.Entry(existing).CurrentValues.SetValues(entity);
      await _dbContext.SaveChangesAsync();
      return existing;
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
      return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
      return await _dbContext.Set<TEntity>().Where(predicate).CountAsync();
    }

    public virtual async Task<long> CountAsync()
    {
      return await _dbContext.Set<TEntity>().CountAsync();
    }

    public virtual async Task<int> DeleteAsync(object id)
    {
      var existing = await _dbContext.Set<TEntity>().FindAsync(id);

      if (existing == null)
        return await Task.FromResult(0);

      _dbContext.Set<TEntity>().Remove(existing);

      return await _dbContext.SaveChangesAsync();
    }
  }
}