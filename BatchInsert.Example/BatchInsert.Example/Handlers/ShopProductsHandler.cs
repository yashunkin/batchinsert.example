using BatchInsert.Example.Dapper;
using BatchInsert.Example.MinimalAPI.ApiModels.Requests;
using BatchInsert.Example.MinimalAPI.Converters;
using BatchInsert.Example.MinimalAPI.Helpers.EndpointRouteHandler;
using BatchInsert.Example.MinimalAPI.Repositories;
using BatchInsert.Example.MinimalAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BatchInsert.Example.MinimalAPI.Handlers;

public class ShopProductsHandler(
    ) 
    : IEndpointRouteHandler
{
   

    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(GetApiMethod(nameof(AddShopsWithProductsRequest)), AddShopsWithProductsAsync);
    }

    private async Task<IResult> AddShopsWithProductsAsync(
        AddShopsWithProductsRequest request,
        ShopProductsService service)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        await service.AddShopsWithProductsAsync(request);

        return Results.Ok();
    }

    private string GetApiMethod(string apiMethod) => $"/api/{apiMethod}";
}