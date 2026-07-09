using Dental.Domain.Entities;

namespace Dental.Domain.Interfaces.Repositories;

public interface IVisitToothTreatmentRepository
 : IRepository<VisitToothTreatment>
{
    Task<decimal> GetTotalCostAsync(
        int visitId,
        CancellationToken cancellationToken = default);

    Task<bool> AreServiceIdAndVisitIdExists(
        int serviceId,
        int visitId);
}