using RTT.Assessment.Domain.Common;

namespace RTT.Assessment.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<T> AddAsync(T entity , CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity , CancellationToken cancellationToken);
    Task<T> DeleteAsync(T entity , CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
}

