namespace BatchInsert.Example.MinimalAPI.ApiModels;

public record Shop(
    string Name,
    string Description,
    IReadOnlyCollection<Product> Products);
