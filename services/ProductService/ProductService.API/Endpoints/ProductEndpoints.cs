using ProductService.Application.Services.Interfaces;

namespace ProductService.API.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("products").WithTags("Products");

        group.MapGet("", async (IProductService service) => await service.GetAllProducts())
            .WithName("GetAllProducts")
            .WithOpenApi();
    }
}
