using Dental.Application.ViewsStuff.Interfaces.Visits;
using Dental.Domain.Repositories.Views.Visits;
using Dental.Domain.Views.Visit;

namespace Dental.Application.ViewsStuff.Services.Visits;

public sealed class VisitRadiographViewService : IVisitRadiographViewService
{
    private readonly IVisitRadiographViewRepository _repo;

    public VisitRadiographViewService(IVisitRadiographViewRepository repo)
    {
        _repo = repo;
    }

    public Task<List<VisitRadiographView>> GetAsync(
        VisitRadiographView? filterDto = null,
        CancellationToken cancellationToken = default)
    {
        return _repo.GetAsync(filterDto, cancellationToken);
    }
}