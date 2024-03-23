namespace BatchInsert.Example.MinimalAPI.ApiModels;

public record Shop(
    long ShopId,
    string? Description,
    IReadOnlyCollection<Product> Products);
