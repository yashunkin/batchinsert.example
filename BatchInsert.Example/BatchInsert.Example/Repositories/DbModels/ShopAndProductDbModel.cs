namespace BatchInsert.Example.MinimalAPI.Repositories.DbModels
{
    public record ShopAndProductDbModel(
        string ShopName,
        string Description,
        string ProductName,
        decimal Price);
}
