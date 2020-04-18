using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TKey id);
        Task RemoveAsync(TEntity entityToDelete);
        Task RemoveAsync(Expression<Func<TEntity, bool>> filter);
        Task EditAsync(TEntity entityToUpdate);
        TEntity Get(Guid id);

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<(IEnumerable<TEntity>, int, int)> GetAsync(
            Expression<Func<TEntity, bool>> filter = null, string orderingColumn = "", string orderDirection = "",
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        (IEnumerable<TEntity>, int, int) Get(
            Expression<Func<TEntity, bool>> filter = null, string orderingColumn = "", string orderDirection = "",
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null, string orderingColumn = "", string orderDirection = "",
            string includeProperties = "", bool isTrackingOff = false);
    }
}
