using BatchInsert.Example.Dapper;
using BatchInsert.Example.MinimalAPI.ApiModels.Requests;
using BatchInsert.Example.MinimalAPI.Helpers.EndpointRouteHandler;
using BatchInsert.Example.MinimalAPI.Repositories;

namespace BatchInsert.Example.MinimalAPI.Handlers;

public class ShopProductsHandler(DbRepository dbRepository) : IEndpointRouteHandler
{
    private readonly DbRepository _dbRepository = dbRepository ?? throw new ArgumentNullException(nameof(dbRepository));

    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(GetApiMethod(nameof(AddShopsWithProductsRequest)), AddShopsWithProductsAsync);
    }

    private async Task<IResult> AddShopsWithProductsAsync(AddShopsWithProductsRequest request)
    {
        throw new NotImplementedException();
    }

    private string GetApiMethod(string apiMethod) => $"api/{apiMethod}";
}