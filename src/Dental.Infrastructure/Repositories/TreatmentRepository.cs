using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class TreatmentRepository(DentalDbContext _dbContext) 
    : Repository<Treatment>(_dbContext), 
        ITreatmentRepository
{
    public Task<bool> ExistsByNameAsync(
        string name,
        int? excludedId = null,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Treatments.AnyAsync(t => t.Name == name && t.Id != excludedId, cancellationToken);
    }
}