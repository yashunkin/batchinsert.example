using BatchInsert.Example.Dapper;
using BatchInsert.Example.MinimalAPI.Repositories.DbTypes;
using Dapper;
using NpgsqlTypes;
using System.Data;

namespace BatchInsert.Example.MinimalAPI.Repositories;

public class DbRepository(ShopsContext dbContext)
{
    private readonly ShopsContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task InsertShopsAndProductsAsync(
        IReadOnlyCollection<ShopDbType> shops,
        IReadOnlyCollection<ProductDbType> products)
    {
        ArgumentNullException.ThrowIfNull(shops, nameof(shops));
        ArgumentNullException.ThrowIfNull(products, nameof(products));

        var parameters = new DynamicParameters(
            new
            {
                shops = shops.ToArray(),
                products = products.ToArray()
            });


        await _dbContext.ExecuteAysnc(
            "select public.insert_shops_and_products(@shops, @products)",
            parameters);
    }
}
