using Dental.Domain.Interfaces.Repositories;
using Dental.Infrastructure.Persistence;

namespace Dental.Infrastructure.Repositories;

public class UnitOfWork(DentalDbContext dbContext) : IUnitOfWork
{
    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}