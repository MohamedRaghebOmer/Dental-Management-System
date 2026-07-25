using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Visit;

namespace Dental.Domain.Repositories.Views.Visits;

public interface IVisitToothTreatmentsViewRepository
{
    Task<List<VisitTreatmentsView>> GetAsync(
        Id visitId,
        CancellationToken cancellationToken = default);
}
