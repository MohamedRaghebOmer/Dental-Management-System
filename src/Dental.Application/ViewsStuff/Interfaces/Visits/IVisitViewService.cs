using Dental.Domain.Views.Visit;

namespace Dental.Application.ViewsStuff.Interfaces.Visits;

public interface IVisitViewService
{
    Task<List<VisitView>> GetAsync(
        VisitView? filterDTO,
        CancellationToken cancellationToken = default);
}
