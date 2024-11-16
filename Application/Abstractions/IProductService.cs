using Application.DTOs;

namespace Application.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task AddProduct(ProductDto product);
    }
}
