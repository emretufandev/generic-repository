using generic_repository.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace generic_repository.Core.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> AsQueryable();
        bool Any(Expression<Func<T, bool>> filter);

        T Get(Expression<Func<T, bool>> filter = null);

        T GetAsNoTracking(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null);

        T Insert(T entity);

        void BulkInsert(IEnumerable<T> entities);

        void BulkUpdate(IEnumerable<T> entities);

        T Update(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);
    }
}
