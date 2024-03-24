using BatchInsert.Example.Dapper;
using BatchInsert.Example.MinimalAPI.Configuration;
using BatchInsert.Example.MinimalAPI.Converters;
using BatchInsert.Example.MinimalAPI.Helpers.EndpointRouteHandler;
using BatchInsert.Example.MinimalAPI.Repositories;
using BatchInsert.Example.MinimalAPI.Repositories.DbTypes;
using BatchInsert.Example.MinimalAPI.Services;
using Npgsql;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AddServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpLogging();

app.MapEndpoints(Assembly.GetExecutingAssembly());

app.Run();


static void AddServices(WebApplicationBuilder builder)
{
    var dbConfig = builder.Configuration.GetSection(nameof(DatabaseConfig));

    builder.Services.Configure<DatabaseConfig>(dbConfig);

    var dbConnString = dbConfig.Get<DatabaseConfig>()!.ToConnectionString();

    var dcBuilder = new NpgsqlDataSourceBuilder(dbConnString);
    MapComposites(dcBuilder);
    var dc = dcBuilder.Build();

    builder.Services.AddScoped<ShopsContext>(c => new(dc));

    builder.Services.AddScoped<DbRepository>();
    builder.Services.AddScoped<ShopProductsService>();
    builder.Services.AddSingleton<RequestToDbConverter>();
    builder.Services.AddSingleton<DbToResponseConverter>();
}

static void MapComposites(NpgsqlDataSourceBuilder builder)
{
    builder.MapComposite<ShopDbType>("shop_type");
    builder.MapComposite<ProductDbType>("product_type");
}