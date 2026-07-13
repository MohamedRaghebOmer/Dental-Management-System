using Dental.Application.Errors;
using Dental.Application.ViewsStuff.Interfaces;
using Dental.Domain.Repositories.Views;
using Dental.Domain.Shared;
using Dental.Domain.Views;
using Microsoft.Extensions.Logging;

namespace Dental.Application.ViewsStuff.Services;

public sealed class VisitToothTreatmentsViewService(
    IVisitToothTreatmentsViewRepository repo,
    ILogger<VisitToothTreatmentsViewService> logger) 
    : IVisitToothTreatmentsViewService
{
    public async Task<Result<List<VisitTreatmentsView>>> GetAsync(
        int visitId, 
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("VisitToothTreatmentsViewService.GetAsync is called. {VisitId}.", visitId);

        if (visitId <= 0)
        {
            logger.LogWarning("Invalid id. {VisitId}", visitId);
            return Result.Failure<List<VisitTreatmentsView>>(ServiceErrors.InvalidId);
        }

        return await repo.GetAsync(visitId, cancellationToken);
    }
}
