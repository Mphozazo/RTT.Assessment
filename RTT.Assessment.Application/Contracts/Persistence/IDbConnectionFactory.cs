using Microsoft.Data.SqlClient;

namespace RTT.Assessment.Application.Contracts.Persistence
{
    public interface IDbConnectionFactory
    {
        Task<SqlConnection> CreateOpenConnectionAsync(CancellationToken ct = default);
    }
}
