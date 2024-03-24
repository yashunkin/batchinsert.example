using Dapper;
using Npgsql;
using System.Data;

namespace BatchInsert.Example.Dapper
{
    public abstract class ContextBase(NpgsqlDataSource dataSource)
    {
        private readonly NpgsqlDataSource _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));

        public async Task<IEnumerable<T>> QueryAysnc<T>(
            string sql,
            object? param = null,
            int? timeout = null,
            CancellationToken ct = default)
        {
            using var connection = await _dataSource.OpenConnectionAsync();

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
            CommandType? commandType = null,
            int? timeout = null,
            CancellationToken ct = default)
        {
            using var connection = await _dataSource.OpenConnectionAsync();

            return await connection.ExecuteAsync(
                new CommandDefinition(
                    sql,
                    param,
                    commandType: commandType,
                    commandTimeout: timeout,
                    cancellationToken: ct));
        }
    }
}
