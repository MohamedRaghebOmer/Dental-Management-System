using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
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
        if (excludedId != null)
        {
            return _dbContext.Treatments.AnyAsync(
                t => t.Name == name && t.Id != Id.FromDatabase(excludedId.Value), cancellationToken);
        }

        return _dbContext.Treatments.AnyAsync(t => t.Name == name);
    }
}