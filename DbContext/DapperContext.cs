using Microsoft.Data.SqlClient;
using Dapper;

namespace DapperNet.DbContext
{
    public class DapperContext : IDisposable
    {
        private readonly SqlConnection _dbConnection;

        public DapperContext(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
            _dbConnection.Open();
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object? parameters = null)
        {
            var result = await _dbConnection.QuerySingleOrDefaultAsync<T>(sql, parameters) ?? throw new InvalidOperationException($"No result found for query: {sql}");
            return result;
        }

        public async Task<List<T>> QueryMultipleAsync<T>(string sql, object? parameters = null)
        {
            var result = await _dbConnection.QueryAsync<T>(sql, parameters);
            return result.ToList();
        }

        public async Task<int> ExecuteAsync(string sql, object? parameters = null)
        {
            return await _dbConnection.ExecuteAsync(sql, parameters);
        }

        public void Dispose()
        {
            _dbConnection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
