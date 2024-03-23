namespace BatchInsert.Example.MinimalAPI.ApiModels.Requests;

public record AddShopsWithProductsRequest(
    IReadOnlyCollection<Shop> Shops);

