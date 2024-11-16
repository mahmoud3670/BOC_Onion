using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Services.Adapter
{
    public static class ProductAdapter
    {
        public static ProductDto ConvertToDto(this Product? product)
        {
            if(product is null)
                return new ProductDto();
            return new ProductDto()
            {
                Name = product.Name,
                Price=product.Price,
            };
        }
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product>? products)
        {
            List < ProductDto > dtos = new List < ProductDto >();
            if (products is null)
                return dtos;

            foreach (var product in products) {
                dtos.Add(ConvertToDto(product));
            }
           return dtos;
        }
        public static Product ConvertToProduct(this ProductDto? dto)
        {
            if (dto is null)
                return new Product();
            return new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
            };
        } 
      
    }
}
