using Application.Abstractions;
using Application.DTOs;
using Domain.Entities;
using Interfaces;
using Services.Adapter;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return (await _unitOfWork.Products.GetListAsync()).ConvertToDto();
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            return (await _unitOfWork.Products.GetAsync(x=>x.Id==id)).ConvertToDto();
        }

        public async Task AddProduct(ProductDto product)
        {
            await _unitOfWork.Products.AddAsync(product.ConvertToProduct());
            await _unitOfWork.CompleteAsync();
        }
    }
}
