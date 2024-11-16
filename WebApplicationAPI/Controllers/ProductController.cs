using Application.Abstractions;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductDto product)
        {
            await _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
    }
}
