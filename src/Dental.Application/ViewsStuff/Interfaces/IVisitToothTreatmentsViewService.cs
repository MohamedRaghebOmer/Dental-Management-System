using Dental.Domain.Shared;
using Dental.Domain.Views;

namespace Dental.Application.ViewsStuff.Interfaces;

public interface IVisitToothTreatmentsViewService
{
    Task<Result<List<VisitTreatmentsView>>> GetAsync(
        int visitId,
        CancellationToken cancellationToken = default);
}
