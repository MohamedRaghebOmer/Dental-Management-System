using Dental.Application.ViewsStuff.Interfaces.Visits;
using Dental.Domain.Repositories.Views.Visits;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Visit;
using Microsoft.Extensions.Logging;

namespace Dental.Application.ViewsStuff.Services.Visits;

public sealed class VisitTreatmentsViewService : IVisitTreatmentsViewService
{
    private readonly IVisitToothTreatmentsViewRepository _repo;
    private readonly ILogger<VisitTreatmentsViewService> _logger;

    public VisitTreatmentsViewService(
        IVisitToothTreatmentsViewRepository repo,
        ILogger<VisitTreatmentsViewService> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<Result<List<VisitTreatmentsView>>> GetAsync(
        int visitId,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "VisitToothTreatmentsViewService.GetAsync is called. {VisitId}.", visitId);

        var createVisitIdResult = Id.Create(visitId);
        if (createVisitIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid id. {VisitId} {Error}", visitId, createVisitIdResult.Error);
            return Result.Failure<List<VisitTreatmentsView>>(createVisitIdResult.Error);
        }

        return await _repo.GetAsync(createVisitIdResult.Value, cancellationToken);
    }
}
