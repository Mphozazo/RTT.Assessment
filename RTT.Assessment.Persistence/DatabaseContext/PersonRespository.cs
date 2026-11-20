using Dapper;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Domain;

namespace RTT.Assessment.Persistence.DatabaseContext
{
    public class PersonRespository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRespository(IDbConnectionFactory factory) : base(factory) { }

        public async Task<bool> PersonExistsAsync(int id, CancellationToken token)
        {
            var sql = $"SELECT CASE WHEN EXISTS (SELECT 1 FROM Persons WHERE [Id] = @id) THEN 1 ELSE 0 END";

            await using var conn = await _factory.CreateOpenConnectionAsync(token);
            return await conn.ExecuteScalarAsync<bool>(
                new CommandDefinition(sql, new { id }, cancellationToken: token));

        }
    }
}
