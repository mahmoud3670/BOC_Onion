using Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Services
{
    public static class ServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductService, ProductService>(); 

            services.AddPersistenceServices(connectionString);
        }
    }
}
