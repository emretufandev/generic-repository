using generic_repository.Core.DataAccess.Abstract;
using generic_repository.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace generic_repository.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        public readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;
        protected bool IsSoftDeletableEntity { get; }

        public EfRepositoryBase(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();

            IsSoftDeletableEntity = typeof(ISoftDeletable).IsAssignableFrom(typeof(TEntity));
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            if (IsSoftDeletableEntity)
            {
                return ((IQueryable<ISoftDeletable>)(this._dbSet))
                    .Where(q => q.IsDeleted == false)
                    .Cast<TEntity>();
            }
            return _dbSet;
        }

        public void BulkInsert(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void BulkUpdate(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            if (IsSoftDeletableEntity)
            {
                var deletableEntity = entity as ISoftDeletable;
                deletableEntity.IsDeleted = true;
                deletableEntity.DeletedTime = DateTime.Now;
                _dbSet.Update(entity);
            }
            else
                _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            if (IsSoftDeletableEntity)
            {
                var softDeletableEntities = entities as IEnumerable<ISoftDeletable>;
                DateTime deletedTime = DateTime.Now;

                foreach (var entity in softDeletableEntities)
                {
                    entity.DeletedTime = deletedTime;
                    entity.IsDeleted = true;
                }

                _dbSet.UpdateRange(entities);
            }
            else
            {
                _dbSet.RemoveRange(entities);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }

        public TEntity GetAsNoTracking(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.AsNoTracking().SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            entity.CreatedTime = DateTime.Now;
            _dbSet.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedTime = DateTime.Now;
            _dbSet.Update(entity);
            return entity;
        }
    }
}
