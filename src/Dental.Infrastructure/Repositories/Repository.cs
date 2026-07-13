using Dental.Domain.Entities;
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
    public async Task AddAsync(TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()
            .AnyAsync(e => e.Id == Id.FromDatabase(id), cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>().FindAsync(
            [Id.FromDatabase(id)],
            cancellationToken);
    }

    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<TEntity>()
            .Where(s => s.Id == Id.FromDatabase(id))
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}