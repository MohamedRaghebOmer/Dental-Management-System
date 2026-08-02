using Dental.Domain.Views.Visit;

namespace Dental.Domain.Repositories.Views.Visits;

public interface IVisitRadiographViewRepository
{
    Task<List<VisitRadiographView>> GetAsync(
        VisitRadiographView? filterDto = null,
        CancellationToken cancellationToken = default);
}