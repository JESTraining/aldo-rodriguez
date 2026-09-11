using ProductService.Application.Models.Requests;
using ProductService.Application.Models.Responses;

namespace ProductService.Application.Services.Interfaces;

public interface IProductService
{
    public Task<IEnumerable<ProductResponse>> GetAllProducts();
    public Task<ProductResponse> GetProductById(int id);
    public Task<ProductResponse> CreateProduct(CreateProductRequest request);
    public Task<ProductResponse> UpdateProduct(CreateProductRequest request);
    public Task DeleteProduct(int id);
}
