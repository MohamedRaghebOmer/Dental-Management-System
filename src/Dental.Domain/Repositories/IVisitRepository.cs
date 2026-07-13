using Dental.Domain.Entities;

namespace Dental.Domain.Repositories;

public interface IVisitRepository
    : IRepository<Visit>
{
    Task<bool> PrescriptionExistsAsync(int prescriptionId,
        CancellationToken cancellationToken = default);

    Task<Visit?> GetVisitByPrescriptionItemIdAsync(
        int prescriptionItemId,
        CancellationToken cancellationToken = default);
}