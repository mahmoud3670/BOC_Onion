using Domain.Common;

namespace Interfaces.Abstractions.Repositories
{
    public interface IRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Query { get; }
    }
}
