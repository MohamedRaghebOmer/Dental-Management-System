using Dental.Domain.ValueObjects;
using Dental.Domain.Views;

namespace Dental.Domain.Repositories.Views;

public interface IVisitToothTreatmentsViewRepository
{
    Task<List<VisitTreatmentsView>> GetAsync(
        Id visitId,
        CancellationToken cancellationToken = default);
}
