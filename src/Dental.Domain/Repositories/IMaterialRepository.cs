using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Repositories;

public interface IMaterialRepository
    : IRepository<Material>
{
    Task<bool> ExistsByNameAsync(
        string name,
        Id? excludeId = null,
        CancellationToken cancellationToken = default);
}