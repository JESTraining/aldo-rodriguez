using ProductService.Application.Services.Interfaces;
using ProductService.Domain.Repositories;
using ProductService.Infrastructure.Repositories;

namespace ProductService.API.Configuration;

public static class ServicesConfiguration
{
    public static void AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, Application.Services.Implementation.ProductService>();
    }
}
