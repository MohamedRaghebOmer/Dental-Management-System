using Dental.Domain.Views;

namespace Dental.Application.ViewsStuff.Interfaces;

public interface IVisitSummaryService
{
    Task<VisitsSummaryView> GetAsync(
        DateTime? dateTime,
        CancellationToken cancellationToken = default);
}
