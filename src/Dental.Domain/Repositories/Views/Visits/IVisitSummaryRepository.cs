using Dental.Domain.Views.Visit;

namespace Dental.Domain.Repositories.Views.Visits;

public interface IVisitSummaryRepository
{
    Task<VisitsSummaryView> GetAsync(
        DateTime? dateTime = null,
        CancellationToken cancellationToken = default);
}
