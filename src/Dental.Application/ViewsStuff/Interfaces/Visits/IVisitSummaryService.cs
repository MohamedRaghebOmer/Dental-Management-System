using Dental.Domain.Views.Visit;

namespace Dental.Application.ViewsStuff.Interfaces.Visits;

public interface IVisitSummaryService
{
    Task<VisitsSummaryView> GetAsync(
        DateTime? dateTime,
        CancellationToken cancellationToken = default);
}
