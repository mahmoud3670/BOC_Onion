using Domain.Entities;
using Interfaces.Abstractions.Repositories;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        Task<int> CompleteAsync();
    }
}
