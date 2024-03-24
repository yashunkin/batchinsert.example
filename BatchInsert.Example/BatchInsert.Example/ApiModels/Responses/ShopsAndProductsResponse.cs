namespace BatchInsert.Example.MinimalAPI.ApiModels.Responses;

public record ShopsAndProductsResponse(
    IReadOnlyCollection<Shop> Shops);
