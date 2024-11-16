using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence
{
    public static class PersistenceConfiguration
    {
        public static void AddPersistenceServices(this IServiceCollection services,string connectionString)
        {
           
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));  

          
            services.AddScoped<IUnitOfWork, UnitOfWork>(); 
           


        }
    }
}
