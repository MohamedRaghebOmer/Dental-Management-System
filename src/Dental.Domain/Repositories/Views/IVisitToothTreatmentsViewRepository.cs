using Dental.Domain.Views;

namespace Dental.Domain.Repositories.Views;

public interface IVisitToothTreatmentsViewRepository
{
    Task<List<VisitTreatmentsView>> GetAsync(
        int visitId,
        CancellationToken cancellationToken = default);
}
