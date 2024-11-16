using Domain.Common;
using Interfaces.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity, new() where TContext : DbContext
    {
        private readonly TContext _context;
        private DbSet<TEntity> Table => _context.Set<TEntity>();
        public IQueryable<TEntity> Query => Table.AsQueryable();

        public Repository(TContext context)
        {
            _context = context;
        }

        #region Read-Metods
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query;
            if (!enableTracking) queryable = Query.AsNoTracking();
            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,  bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (predicate != null) queryable = queryable.Where(predicate);
            return await Task.FromResult(queryable);
        }

        #endregion
        #region Write-Metods
        public async Task AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public Task Remove(TEntity entity)
        {
            Table.Remove(entity);
            return Task.CompletedTask;
        }

        public Task RemoveRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task Update(TEntity entity)
        {
            Table.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateRange(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
            return Task.CompletedTask;
        }
        #endregion

    }
}
