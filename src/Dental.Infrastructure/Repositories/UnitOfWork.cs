using Dental.Domain.Repositories;
using Dental.Infrastructure.Persistence;

namespace Dental.Infrastructure.Repositories;

public sealed class UnitOfWork(DentalDbContext dbContext) : IUnitOfWork
{
    public Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task BeginTransactionAsync(
        CancellationToken cancellationToken = default)
    {
        return dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task RollbackTransactionAsync(
        CancellationToken cancellationToken = default)
    {
        return dbContext.Database.RollbackTransactionAsync(cancellationToken);
    }

    public Task CommitTransactionAsync(
        CancellationToken cancellationToken = default)
    {
        return dbContext.Database.CommitTransactionAsync(cancellationToken);
    }
}