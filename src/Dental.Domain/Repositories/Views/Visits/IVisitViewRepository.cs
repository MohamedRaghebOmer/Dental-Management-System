using Dental.Domain.Views.Visit;

namespace Dental.Domain.Repositories.Views.Visits;

public interface IVisitViewRepository
{
    Task<List<VisitView>> GetAsync(
        VisitView? filterDto = null,
        CancellationToken cancellationToken = default);
}
