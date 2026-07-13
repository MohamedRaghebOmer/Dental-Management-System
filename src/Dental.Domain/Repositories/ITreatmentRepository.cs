using Dental.Domain.Entities;

namespace Dental.Domain.Repositories;

public interface ITreatmentRepository
    : IRepository<Treatment>
{
    Task<bool> ExistsByNameAsync(
        string name,
        int? excludedId = null,
        CancellationToken  cancellationToken = default);
}