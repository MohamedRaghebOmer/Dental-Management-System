using Dental.Domain.Views;

namespace Dental.Domain.Repositories.Views;

public interface IVisitSummaryRepository
{
    Task<VisitsSummaryView> GetAsync(
        DateTime? dateTime,
        CancellationToken cancellationToken = default);
}
