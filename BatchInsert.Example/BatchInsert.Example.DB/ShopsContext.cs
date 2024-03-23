namespace BatchInsert.Example.Dapper;

public class ShopsContext : ContextBase
{
    protected ShopsContext(string connectionString) 
        : base(connectionString)
    {
    }
}
