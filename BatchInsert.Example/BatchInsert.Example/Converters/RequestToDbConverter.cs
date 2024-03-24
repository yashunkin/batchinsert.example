using BatchInsert.Example.MinimalAPI.ApiModels.Requests;
using BatchInsert.Example.MinimalAPI.Repositories.DbTypes;

namespace BatchInsert.Example.MinimalAPI.Converters;

public class RequestToDbConverter
{
    public (IReadOnlyCollection<ShopDbType>,  IReadOnlyCollection<ProductDbType>) Convert(AddShopsWithProductsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var shops = new List<ShopDbType>();
        var products = new List<ProductDbType>();

        foreach (var shop in request.Shops)
        {
            shops.Add(new ShopDbType
            {
                ShopName = shop.Name,
                Description = shop.Description
            });

            products.AddRange(shop.Products.Select(p => new ProductDbType
            {
                ShopName = shop.Name,
                ProductName = p.Name,
                Price = p.Price
            }));
        }
               
        return new(shops, products);
    }
}
