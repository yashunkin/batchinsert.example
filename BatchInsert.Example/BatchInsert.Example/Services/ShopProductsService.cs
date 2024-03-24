using BatchInsert.Example.MinimalAPI.ApiModels.Requests;
using BatchInsert.Example.MinimalAPI.ApiModels.Responses;
using BatchInsert.Example.MinimalAPI.Converters;
using BatchInsert.Example.MinimalAPI.Repositories;
using BatchInsert.Example.MinimalAPI.Repositories.DbModels;

namespace BatchInsert.Example.MinimalAPI.Services;

public class ShopProductsService(
    DbRepository dbRepository,
    RequestToDbConverter requestToDbConverter,
    DbToResponseConverter dbToResponseConverter)
{
    private readonly DbRepository _dbRepository = dbRepository ?? throw new ArgumentNullException(nameof(dbRepository));
    private readonly RequestToDbConverter _requestToDbConverter = requestToDbConverter ?? throw new ArgumentNullException(nameof(requestToDbConverter));
    private readonly DbToResponseConverter _dbToResponseConverter = dbToResponseConverter ?? throw new ArgumentNullException(nameof(dbToResponseConverter));

    public async Task AddShopsAndProductsAsync(AddShopsAndProductsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var dbData = _requestToDbConverter.Convert(request);

        await _dbRepository.InsertShopsAndProductsAsync(dbData.Item1, dbData.Item2);
    }

    public async Task<ShopsAndProductsResponse> GetShopsAndProductsAsync()
    {
        var dbData = await _dbRepository.SelectShopsAndProductsAsync();

        return _dbToResponseConverter.Convert(dbData);
    }
}
