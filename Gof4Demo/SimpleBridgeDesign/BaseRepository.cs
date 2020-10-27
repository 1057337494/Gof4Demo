using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TY.Microservice.Common.Abstractions;

namespace TY.Microservice.Common.Core
{
    public abstract class BaseRepository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : Entity where TDbContext : EFContext
    {
        protected BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual TDbContext DbContext { get; set; }

        public virtual IUnitOfWork UnitOfWork => DbContext;

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> exp, Expression<Func<TEntity, bool>> orderby, bool isAsc = false)
        {
            var query = DbContext.Set<TEntity>().Where(exp);
            if (isAsc)
                query = query.OrderBy(orderby);
            else
                query = query.OrderByDescending(orderby);

            return query.ToList();
        }

        public IEnumerable<TEntity> GetPage(Expression<Func<TEntity, bool>> exp, int pageIndex, int pageSize)
        {
            return DbContext.Set<TEntity>().Where(exp).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetPage(Expression<Func<TEntity, bool>> exp, Expression<Func<TEntity, object>> orderby, int pageIndex, int pageSize, bool isAsc = false)
        {
            var query = DbContext.Set<TEntity>().Where(exp);
            if (isAsc)
                query = query.OrderBy(orderby);
            else
                query = query.OrderByDescending(orderby);
             
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public long GetTotal(Expression<Func<TEntity, bool>> exp)
        {
            return DbContext.Set<TEntity>().Where(exp).Count();
        }


        public TEntity Add(TEntity entity)
        {
            return DbContext.Add(entity).Entity;
        }



        public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Add(entity));
        }

        public TEntity Update(TEntity entity)
        {
            return DbContext.Update(entity).Entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Update(entity));
        }

        public bool Remove(TEntity entity)
        {
            DbContext.Remove(entity);
            return true;
        }

        public Task<bool> RemoveAsync(TEntity entity)
        {
            return Task.FromResult(Remove(entity));
        }
    }

    public abstract class BaseRepository<TEntity, TKey, TDbContext> : BaseRepository<TEntity, TDbContext>, IRepository<TEntity, TKey> where TEntity : Entity<TKey> where TDbContext : EFContext
    {
        protected BaseRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        public bool Delete(TKey id)
        {
            var entity = DbContext.Find<TEntity>(id);
            if (entity == null)
            {
                return false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.FindAsync<TEntity>(id, cancellationToken);
            if (entity == null)
            {
                return false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public TEntity Get(TKey id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> exp)
        {
            return DbContext.Set<TEntity>().Where(exp).ToList();
        }

        public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await DbContext.FindAsync<TEntity>(id, cancellationToken);
        }
    }
}
