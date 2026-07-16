using Dental.Domain.Primitives;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public class Repository<TEntity>(DentalDbContext _dbContext)
    : IRepository<TEntity>
    where TEntity : Entity
{
    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public Task<bool> ExistsAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<TEntity>()
            .AnyAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()
            .FindAsync([id], cancellationToken);
    }

    public async Task<bool> RemoveAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);

        if (entity is null)
            return false;

        _dbContext.Set<TEntity>()
            .Remove(entity);

        return true;
    }

    public Task<List<TEntity>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }
}