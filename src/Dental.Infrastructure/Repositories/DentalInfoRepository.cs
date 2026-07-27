using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class DentalInfoRepository(DentalDbContext dbContext)
    : IDentalInfoRepository
{
    public Task<DentalInfo> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return dbContext.DentalInfo.FirstAsync(cancellationToken);
    }

    public Task SetAsync(
        DentalInfo info,
        CancellationToken cancellationToken = default)
    {
        return dbContext.DentalInfo
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.DoctorName, info.DoctorName)
                    .SetProperty(x => x.PhoneNumber, info.PhoneNumber)
                    .SetProperty(x => x.DoctorPicturePath, info.DoctorPicturePath)
                    .SetProperty(x => x.DentalName, info.DentalName)
                    .SetProperty(x => x.DentalDescription, info.DentalDescription)
                    .SetProperty(x => x.DentalPicturePath, info.DentalPicturePath),
                cancellationToken);
    }
}