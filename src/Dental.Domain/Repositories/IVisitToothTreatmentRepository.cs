using Dental.Domain.Entities;

namespace Dental.Domain.Repositories;

public interface IVisitToothTreatmentRepository
 : IRepository<VisitToothTreatment>
{
    Task<decimal> GetTotalCostAsync(
        int visitId,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsByToothNumberAndServiceIdAndVisitId(
        byte toothNumber,
        int serviceId,
        int visitId,
        int? excludedId = null,
        CancellationToken cancellationToken = default);
}