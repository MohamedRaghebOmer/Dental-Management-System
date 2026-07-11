using Dental.Domain.Entities;

namespace Dental.Domain.Repositories;

public interface IDentalInfoRepository
{
    Task<DentalInfo?> GetAsync(CancellationToken cancellationToken);
}