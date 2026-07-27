using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Material;

namespace Dental.Domain.Repositories;

public interface IMaterialRepository
    : IRepository<Material>
{
    Task<bool> ExistsByNameAsync(
        string name,
        Id? excludeId = null,
        CancellationToken cancellationToken = default);

    Task<List<MaterialFilterDto>> FilterAsync(
        MaterialFilterDto? filterDto = null,
        CancellationToken cancellationToken = default);
}