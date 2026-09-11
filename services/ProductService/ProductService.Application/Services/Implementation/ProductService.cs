using ProductService.Application.Models.Requests;
using ProductService.Application.Models.Responses;
using ProductService.Application.Services.Interfaces;
using ProductService.Domain.Repositories;

namespace ProductService.Application.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductResponse>> GetAllProducts()
    {
        var products = await _productRepository.GetAll();

        return products.Select(x => new ProductResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            ImageUrl = x.ImageUrl,
            CategoryId = x.CategoryId
        });
    }

    public async Task<ProductResponse> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponse> CreateProduct(CreateProductRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponse> UpdateProduct(CreateProductRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}
