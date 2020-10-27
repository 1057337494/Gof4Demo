using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TY.Microservice.Common.Core
{
    public interface IRepository<TEntity,TKey>: IRepository<TEntity>
    {
        bool Delete(TKey id);
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);
    }

    public interface IRepository<TEntity>: IRepository
    {
        IUnitOfWork UnitOfWork { get; }
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        bool Remove(TEntity entity);
        Task<bool> RemoveAsync(TEntity entity);
    }

    public interface IRepository
    {
        
    }
}
