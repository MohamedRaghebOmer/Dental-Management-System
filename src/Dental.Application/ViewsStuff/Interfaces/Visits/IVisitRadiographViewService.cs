using Dental.Domain.Views.Visit;

namespace Dental.Application.ViewsStuff.Interfaces.Visits;

public interface IVisitRadiographViewService
{
    Task<List<VisitRadiographView>> GetAsync(
        VisitRadiographView? filterDto = null,
        CancellationToken cancellationToken = default);
}