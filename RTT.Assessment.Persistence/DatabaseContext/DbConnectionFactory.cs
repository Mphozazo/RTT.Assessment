using Microsoft.Data.SqlClient;
using RTT.Assessment.Application.Contracts.Persistence;

namespace RTT.Assessment.Persistence.DatabaseContext;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(string connectionString)
        => _connectionString = connectionString;

    public async Task<SqlConnection> CreateOpenConnectionAsync(CancellationToken ct = default)
    {
        var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync(ct);
        return conn;
    }
   
}
