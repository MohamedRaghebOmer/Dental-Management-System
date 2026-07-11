using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class MaterialRepository(DentalDbContext _dbContext)
    : Repository<Material>(_dbContext), 
        IMaterialRepository
{
    public Task<bool> ExistsByNameAsync(
        string name, 
        int? excludeId = null, 
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Materials.AnyAsync(m => m.Name == name && m.Id.Value != excludeId, cancellationToken);
    }
}