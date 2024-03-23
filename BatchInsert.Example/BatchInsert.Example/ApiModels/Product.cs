namespace BatchInsert.Example.MinimalAPI.ApiModels;

public record Product(
    long ProductId,
    string? Description);