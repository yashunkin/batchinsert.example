namespace BatchInsert.Example.MinimalAPI.ApiModels.Requests;

public record AddShopsAndProductsRequest(
    IReadOnlyCollection<Shop> Shops);

