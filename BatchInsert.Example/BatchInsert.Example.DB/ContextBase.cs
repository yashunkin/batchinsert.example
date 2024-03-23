using Dapper;
using Npgsql;
using System.Data;

namespace BatchInsert.Example.Dapper
{
    public class ContextBase
    {
        private readonly string _connectionString;

        protected ContextBase(string connectionString) 
            => _connectionString = !string.IsNullOrWhiteSpace(connectionString)
                ? connectionString
                : throw new ArgumentException(nameof(connectionString));

        protected virtual IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);

        public async Task<IEnumerable<T>> QueryAysnc<T>(
            string sql,
            object? param = null,
            int? timeout = null,
            CancellationToken ct = default)
        {
            using var connection = CreateConnection();

            return await connection.QueryAsync<T>(
                new CommandDefinition(
                    sql,
                    param,
                    commandTimeout: timeout,
                    cancellationToken: ct));
        }

        public async Task<int> ExecuteAysnc(
            string sql,
            object? param = null,
            int? timeout = null,
            CancellationToken ct = default)
        {
            using var connection = CreateConnection();

            return await connection.ExecuteAsync(
                new CommandDefinition(
                    sql,
                    param,
                    commandTimeout: timeout,
                    cancellationToken: ct));
        }
    }
}
