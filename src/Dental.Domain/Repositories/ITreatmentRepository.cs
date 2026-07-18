using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Repositories;

public interface ITreatmentRepository
    : IRepository<Treatment>
{
    Task<bool> ExistsByNameAsync(
        string name,
        Id? excludedId = null,
        CancellationToken cancellationToken = default);

    Task<Money?> GetPriceByIdAsync(
        Id id,
        CancellationToken cancellation = default);

    Task<Dictionary<int, decimal>> GetPricesByIdsAsync(
        IEnumerable<Id> ids,
        CancellationToken cancellationToken = default);

    Task<Dictionary<int, decimal>> GetAllIdsAndPricesAsync(
    CancellationToken cancellationToken = default);

}