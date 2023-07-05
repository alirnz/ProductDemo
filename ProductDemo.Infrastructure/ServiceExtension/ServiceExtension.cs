using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductDemo.Core.Interfaces;
using ProductDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ProductDemo.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
        
           // services.AddDbContext<DbContextClass>(options =>
            //{
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
               

            //});

            services.AddScoped<IProductsDemo, ProductsDemo>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
