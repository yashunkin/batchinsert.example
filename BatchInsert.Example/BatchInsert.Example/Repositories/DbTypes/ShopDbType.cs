using NpgsqlTypes;

namespace BatchInsert.Example.MinimalAPI.Repositories.DbTypes
{
    public class ShopDbType
    {
        [PgName("shop_name")]
        public string ShopName { get; set; } = default!;
        [PgName("description")]
        public string Description { get; set; } = default!;
    }
}
