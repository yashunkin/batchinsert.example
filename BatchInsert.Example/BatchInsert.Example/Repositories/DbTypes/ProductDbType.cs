using NpgsqlTypes;

namespace BatchInsert.Example.MinimalAPI.Repositories.DbTypes
{
    public class ProductDbType
    {
        [PgName("shop_name")]
        public string ShopName { get; set; } = default!;
        [PgName("product_name")]
        public string ProductName { get; set; } = default!;
        [PgName("price")]
        public decimal Price { get; set; }
    }
        
}
