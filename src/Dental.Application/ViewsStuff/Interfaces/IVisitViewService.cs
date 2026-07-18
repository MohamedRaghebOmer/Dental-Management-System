using Dental.Domain.Views;

namespace Dental.Application.ViewsStuff.Interfaces;

public interface IVisitViewService
{
    Task<List<VisitView>> GetAsync(
        Domain.Views.VisitView? filterDTO,
        CancellationToken cancellationToken = default);
}
