using Dental.Domain.Views;

namespace Dental.Domain.Repositories.Views;

public interface IVisitViewRepository
{
    Task<List<VisitView>> GetAsync(
        VisitView? filterDTO,
        CancellationToken cancellationToken = default);
}
