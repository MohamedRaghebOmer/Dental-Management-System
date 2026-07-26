using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class MaterialRepository
    : Repository<Material>,
        IMaterialRepository
{
    private readonly DentalDbContext _dbContext;
    private readonly IMaterialRepository _materialRepository;

    public MaterialRepository(
        DentalDbContext dbContext,
        IMaterialRepository materialRepository)
        : base(dbContext)
    {
        _dbContext = dbContext;
        _materialRepository = materialRepository;
    }

    public Task<bool> ExistsByNameAsync(
        string name,
        Id? excludeId = null,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Materials.AnyAsync(
            m => m.Name == name && m.Id != excludeId, cancellationToken);
    }
}