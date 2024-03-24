using Npgsql;

namespace BatchInsert.Example.Dapper;

public class ShopsContext(NpgsqlDataSource dataSource) 
    : ContextBase(dataSource)
{
}
