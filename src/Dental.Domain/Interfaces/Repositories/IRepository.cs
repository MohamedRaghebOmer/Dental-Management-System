using Dental.Domain.Primitives;

namespace Dental.Domain.Interfaces.Repositories;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    Task AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>> GetAllAsync(
        CancellationToken cancellationToken);
}