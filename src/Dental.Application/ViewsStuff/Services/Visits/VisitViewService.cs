using Dental.Application.ViewsStuff.Interfaces.Visits;
using Dental.Domain.Repositories.Views.Visits;
using Dental.Domain.Views.Visit;

namespace Dental.Application.ViewsStuff.Services.Visits;

public class VisitViewService : IVisitViewService
{
    private readonly IVisitViewRepository _repo;

    public VisitViewService(IVisitViewRepository repo)
        => _repo = repo;

    public Task<List<VisitView>> GetAsync(
        VisitView? filterDTO,
        CancellationToken cancellationToken = default)
    {
        return _repo.GetAsync(filterDTO, cancellationToken);
    }

}
