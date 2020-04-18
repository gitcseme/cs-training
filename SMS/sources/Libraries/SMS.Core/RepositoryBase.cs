using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SMS.Core
{
    public abstract class RepositoryBase<TEntity, TKey, TContext>
        : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TContext : DbContext
    {
        protected TContext _dbContext;
        protected DbSet<TEntity> _DbSet;
        
        protected RepositoryBase(TContext context)
        {
            _dbContext = context;
            _DbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _DbSet.AddAsync(entity);
        }

        public virtual async Task RemoveAsync(TKey id)
        {
            var entityToDelete = _DbSet.Find(id);
            await RemoveAsync(entityToDelete);
        }

        public virtual async Task RemoveAsync(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _DbSet.Attach(entityToDelete);
                }
                _DbSet.Remove(entityToDelete);
            });
        }

        public virtual async Task RemoveAsync(Expression<Func<TEntity, bool>> filter)
        {
            await Task.Run(() =>
            {
                _DbSet.RemoveRange(_DbSet.Where(filter));
            });
        }

        public virtual async Task EditAsync(TEntity entityToUpdate)
        {
            await Task.Run(() =>
            {
                _DbSet.Attach(entityToUpdate);
                _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            });
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _DbSet;
            int count;

            if (filter != null)
            {
                query = query.Where(filter);
                count = await query.CountAsync();
            }
            else
                count = await query.CountAsync();

            return count;
        }


        public virtual async Task<(IEnumerable<TEntity>, int, int)> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            string orderingColumn = "", string orderDirection = "", string includeProperties = "", 
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<TEntity> query = _DbSet;
            int total = query.Count();
            int totalDisplay = total;

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            IEnumerable<TEntity> data;
            IQueryable<TEntity> result;

            if (orderingColumn != "")
            {
                string orderByColDir = (orderingColumn + (orderDirection != "" ? $" {orderDirection}" : ""));
                result = query.OrderBy(orderByColDir).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
                result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            if (isTrackingOff)
                data = await result.AsNoTracking().ToListAsync();
            else
                data = await result.ToListAsync();

            return (data, total, totalDisplay);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, 
            string orderingColumn = "", string orderDirection = "", 
            string includeProperties = "", bool isTrackingOff = false)
        {
            IQueryable<TEntity> query = _DbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderingColumn != "")
            {
                string orderByColDir = (orderingColumn + (orderDirection != "" ? $" {orderDirection}" : ""));
                query = query.OrderBy(orderByColDir);
            }

            if (isTrackingOff)
                return await query.AsNoTracking().ToListAsync();
            else
                return await query.ToListAsync();
        }

        public (IEnumerable<TEntity>, int, int) Get(Expression<Func<TEntity, bool>> filter = null,
            string orderingColumn = "", string orderDirection = "", string includeProperties = "", 
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<TEntity> query = _DbSet;
            int total = query.Count();
            int totalDisplay = total;

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            IEnumerable<TEntity> data;
            IQueryable<TEntity> result;

            if (orderingColumn != "")
            {
                string orderByColDir = (orderingColumn + (orderDirection != "" ? $" {orderDirection}" : ""));
                result = query.OrderBy(orderByColDir).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
                result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            if (isTrackingOff)
                data = result.AsNoTracking().ToList();
            else
                data = result.ToList();

            return (data, total, totalDisplay);
        }

        public TEntity Get(Guid id)
        {
            return _DbSet.Find(id);
        }
    }
}
