using BatchInsert.Example.MinimalAPI.ApiModels.Requests;
using BatchInsert.Example.MinimalAPI.Converters;
using BatchInsert.Example.MinimalAPI.Repositories;

namespace BatchInsert.Example.MinimalAPI.Services;

public class ShopProductsService(
    DbRepository dbRepository,
    RequestToDbConverter requestToDbConverter)
{
    private readonly DbRepository _dbRepository = dbRepository ?? throw new ArgumentNullException(nameof(dbRepository));
    private readonly RequestToDbConverter _requestToDbConverter = requestToDbConverter ?? throw new ArgumentNullException(nameof(requestToDbConverter));

    public async Task AddShopsWithProductsAsync(AddShopsWithProductsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var dbData = _requestToDbConverter.Convert(request);

        await _dbRepository.InsertShopsAndProductsAsync(dbData.Item1, dbData.Item2);
    }
}
