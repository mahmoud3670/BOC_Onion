using Domain.Common;

namespace Interfaces.Abstractions.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task Update(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entities);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);
        
    }
}
