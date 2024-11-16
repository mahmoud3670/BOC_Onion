using Domain.Common;
using System.Linq.Expressions;

namespace Interfaces.Abstractions.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,bool enableTracking = true);

        Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = true);
    }
}
