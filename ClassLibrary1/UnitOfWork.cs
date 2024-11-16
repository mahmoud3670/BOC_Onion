using Domain.Entities;
using Interfaces;
using Interfaces.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IRepository<Product> _productRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _productRepository ??= new Repository<Product, AppDbContext>(_context);
        }

        public IRepository<Product> Products => _productRepository;



        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
