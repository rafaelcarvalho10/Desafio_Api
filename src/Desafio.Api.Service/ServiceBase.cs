using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.Api.Domain.Interface.Repositories;
using Desafio.Api.Interface.Services;

namespace Desafio.Api.Service
{
  public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
  {
    private readonly IRepositoryBase<TEntity> _repository;

    protected ServiceBase(IRepositoryBase<TEntity> repository)
    {
      _repository = repository;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
      return await this._repository.AddAsync(entity);
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
      return await this._repository.GetAllAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
      return await this._repository.GetByIdAsync(id);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, Guid id)
    {
      return await this._repository.UpdateAsync(entity, id);
    }

    public virtual async Task<int> DeleteAsync(Guid id)
    {
      return await this._repository.DeleteAsync(id);
    }
  }
}