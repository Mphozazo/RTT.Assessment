using Dapper;
using Dapper.Contrib.Extensions;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Domain.Common;
using RTT.Assessment.Persistence.EntityMappingHelper;

namespace RTT.Assessment.Persistence.DatabaseContext
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly IDbConnectionFactory _factory;
        public GenericRepository(IDbConnectionFactory factory) => _factory = factory;

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await using var conn = await _factory.CreateOpenConnectionAsync(cancellationToken);
            entity.DateCreated = DateTime.UtcNow;
            entity.DateUpdated = DateTime.UtcNow;
            entity.Id = await conn.QuerySingleAsync<int>(
                new CommandDefinition(DapperEntityMap<T>.Insert, entity, cancellationToken: cancellationToken));
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            await using var conn = await _factory.CreateOpenConnectionAsync(cancellationToken);
            var rows = await conn.QueryAsync<T>(
                new CommandDefinition(DapperEntityMap<T>.SelectAll, cancellationToken: cancellationToken));
            return rows.AsList();
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            await using var conn = await _factory.CreateOpenConnectionAsync(cancellationToken);
            return await conn.QuerySingleOrDefaultAsync<T>(
                new CommandDefinition(DapperEntityMap<T>.SelectById, new { id }, cancellationToken: cancellationToken));

        }

        public async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            await using var conn = await _factory.CreateOpenConnectionAsync(cancellationToken);
            await conn.ExecuteAsync(
                new CommandDefinition(DapperEntityMap<T>.Delete, new { Id = entity.Id }, cancellationToken: cancellationToken));
            return entity;  
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            await using var conn = await _factory.CreateOpenConnectionAsync(cancellationToken);
            entity.DateUpdated = DateTime.UtcNow;
            await conn.ExecuteAsync(
                new CommandDefinition(DapperEntityMap<T>.Update, entity, cancellationToken: cancellationToken));
            return entity;
        }
    }
}
