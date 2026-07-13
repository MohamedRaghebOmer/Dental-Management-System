using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class DentalInfoRepository(DentalDbContext dbContext)
    : IDentalInfoRepository
{
    public async Task<DentalInfo?> GetAsync(CancellationToken cancellationToken)
    {
        // There is must be one and only one DentalInfo record in the database, so we can use FirstAsync instead of FirstOrDefaultAsync
        return await dbContext.DentalInfo.FirstAsync(cancellationToken);
    }
}