using Dental.Domain.Entities;

namespace Dental.Domain.Repositories;

public interface IMaterialRepository
 : IRepository<Material>
{
    Task<bool> ExistsByNameAsync(
        string name, 
        int? excludeId = null, 
        CancellationToken cancellationToken = default);
}