using Dental.Application.ViewsStuff.Interfaces;
using Dental.Domain.Repositories.Views;
using Dental.Domain.Views;

namespace Dental.Application.ViewsStuff.Services;

public class VisitSummaryService : IVisitSummaryService
{
    private readonly IVisitSummaryRepository _repo;

    public VisitSummaryService(IVisitSummaryRepository repo)
        => _repo = repo;

    public Task<VisitsSummaryView> GetAsync(
        DateTime? dateTime,
        CancellationToken cancellationToken = default)
    {
        return _repo.GetAsync(dateTime, cancellationToken);
    }

}
