using BatchInsert.Example.Dapper;

namespace BatchInsert.Example.MinimalAPI.Repositories;

public class DbRepository(ShopsContext dbContext)
{
    private readonly ShopsContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));


}
