using Dental.Application.ViewsStuff.Interfaces;
using Dental.Domain.Repositories.Views;
using Dental.Domain.Views;

namespace Dental.Application.ViewsStuff.Services;

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
