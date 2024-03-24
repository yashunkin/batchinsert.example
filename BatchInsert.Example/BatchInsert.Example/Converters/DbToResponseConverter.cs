using BatchInsert.Example.MinimalAPI.ApiModels;
using BatchInsert.Example.MinimalAPI.ApiModels.Responses;
using BatchInsert.Example.MinimalAPI.Repositories.DbModels;

namespace BatchInsert.Example.MinimalAPI.Converters;

public class DbToResponseConverter
{
    public ShopsAndProductsResponse Convert(IEnumerable<ShopAndProductDbModel> dbData)
    {
        var shopsAndProducts = dbData.GroupBy(x => new { x.ShopName, x.Description })
            .Select(s => new Shop(
                s.Key.ShopName,
                s.Key.Description,
                s.Select(p => new Product(
                    p.ProductName,
                    p.Price)).ToList()
                )).ToList();

        return new ShopsAndProductsResponse(shopsAndProducts);
    }
}
