using Domain.Entities;

namespace Application.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
    }
}
