using Dental.Domain.Shared;
using Dental.Domain.Views.Visit;

namespace Dental.Application.ViewsStuff.Interfaces.Visits;

public interface IVisitTreatmentsViewService
{
    Task<Result<List<VisitTreatmentsView>>> GetAsync(
        int visitId,
        CancellationToken cancellationToken = default);
}
