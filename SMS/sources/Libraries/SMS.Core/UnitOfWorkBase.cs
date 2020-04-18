using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core
{
    public abstract class UnitOfWorkBase<TContext> : IUnitOfWorkBase
        where TContext : DbContext
    {
        protected readonly TContext _dbContext;

        protected UnitOfWorkBase(string connectionStringName, string migrationAssemblyName)
        {
            _dbContext = (TContext) Activator.CreateInstance(typeof(TContext), connectionStringName, migrationAssemblyName);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
