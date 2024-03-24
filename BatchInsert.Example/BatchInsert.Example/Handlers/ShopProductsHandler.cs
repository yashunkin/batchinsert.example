using BatchInsert.Example.MinimalAPI.ApiModels.Requests;
using BatchInsert.Example.MinimalAPI.Helpers.EndpointRouteHandler;
using BatchInsert.Example.MinimalAPI.Services;

namespace BatchInsert.Example.MinimalAPI.Handlers;

public class ShopProductsHandler() : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(GetApiMethod("AddShopsAndProducts"), AddShopsAndProductsAsync);
        app.MapGet(GetApiMethod("GetShopsAndProducts"), GetShopsAndProductsAsync);
    }

    private async Task<IResult> GetShopsAndProductsAsync(ShopProductsService service)
    {
        var result = await service.GetShopsAndProductsAsync();

        return Results.Ok(result);
    }

    private async Task<IResult> AddShopsAndProductsAsync(
        AddShopsAndProductsRequest request,
        ShopProductsService service)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        await service.AddShopsAndProductsAsync(request);

        return Results.Ok();
    }

    private string GetApiMethod(string apiMethod) => $"/api/{apiMethod}";
}