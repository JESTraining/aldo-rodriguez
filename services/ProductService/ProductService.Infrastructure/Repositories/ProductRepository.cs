using ProductService.Domain.Entities;
using ProductService.Domain.Repositories;

namespace ProductService.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public override async Task<IEnumerable<Product>> GetAll()
    {
        var mockProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.00M, ImageUrl = "https://example.com/image1.jpg", CategoryId = 1 },
            new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20.00M, ImageUrl = "https://example.com/image2.jpg", CategoryId = 2 }
        };

        return await Task.FromResult(mockProducts);
    }
}
