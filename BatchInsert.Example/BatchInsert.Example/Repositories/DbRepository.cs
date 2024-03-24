using BatchInsert.Example.Dapper;
using BatchInsert.Example.MinimalAPI.Repositories.DbModels;
using BatchInsert.Example.MinimalAPI.Repositories.DbTypes;
using Dapper;

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

    public async Task<IEnumerable<ShopAndProductDbModel>> SelectShopsAndProductsAsync()
    {
        var query = @"
            select
	            s.""name"" as shopname,
	            s.description,
	            p.""name"" as productname,
	            p.price
            from public.shop_products sp 
            inner join public.shops s on s.shop_id = sp.shop_id 
            inner join public.products p on p.product_id = sp.product_id
            order by s.""name"", p.""name""";

        return await _dbContext.QueryAysnc<ShopAndProductDbModel>(query);
    }
}
