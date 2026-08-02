using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.VisitPayment;
using Dental.Application.Errors;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Dental.Application.Services;

public sealed class VisitPaymentService
    : IVisitPaymentService
{
    private readonly IVisitRepository _visitRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VisitPaymentService> _logger;

    public VisitPaymentService(
        IVisitRepository visitRepo,
        IUnitOfWork unitOfWork,
        ILogger<VisitPaymentService> logger)
    {
        _visitRepo = visitRepo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result> UpdateManyAsync(
        List<UpdateVisitPaymentDto> updateDtos,
        CancellationToken cancellationToken = default)
    {
        HashSet<Id> visitsIds = [];
        foreach (var visitPaymentDto in updateDtos)
        {
            var visitIdResult = Id.Create(visitPaymentDto.VisitId);
            if (visitIdResult.IsFailure)
                return Result.Failure(ServiceErrors.Common.InvalidId);

            visitsIds.Add(visitIdResult.Value);
        }

        var visits =
            await _visitRepo.GetByIdsAsync(
                visitsIds,
                cancellationToken,
                v => v.VisitPayments);

        foreach (var dto in updateDtos)
        {
            var paymentIdResult = Id.Create(dto.VisitPaymentId);
            if (paymentIdResult.IsFailure)
                return Result.Failure(ServiceErrors.Common.InvalidId);

            var paidAmountResult = Money.Create(dto.PaidAmount);
            if (paidAmountResult.IsFailure)
                return Result.Failure(paidAmountResult.Error);

            if (!visits.TryGetValue(dto.VisitId, out var visit))
                return Result.Failure(ServiceErrors.VisitPayment.VisitNotFound);

            var updateResult = visit.UpdateVisitPayment(
                paymentIdResult.Value,
                paidAmountResult.Value);

            if (updateResult.IsFailure)
                return Result.Failure(updateResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> CreateMenyAsync(
        List<CreateVisitPaymentDto> addDtos,
        CancellationToken cancellationToken = default)
    {
        HashSet<Id> visitIds = [];

        foreach (var dto in addDtos)
        {
            var visitIdResult = Id.Create(dto.VisitId);
            if (visitIdResult.IsFailure)
                return Result.Failure(ServiceErrors.Common.InvalidId);

            visitIds.Add(visitIdResult.Value);
        }

        var visits =
            await _visitRepo.GetByIdsAsync(visitIds, cancellationToken);

        foreach (var dto in addDtos)
        {
            if (!visits.TryGetValue(dto.VisitId, out var visit))
                return Result.Failure(ServiceErrors.Common.NotFound);

            var paidAmountResult = Money.Create(dto.PaidAmount);
            if (paidAmountResult.IsFailure)
                return Result.Failure(paidAmountResult.Error);

            var createVisitResult = visit.AddVisitPayment(paidAmountResult.Value);
            if (createVisitResult.IsFailure)
                return Result.Failure(createVisitResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> DeleteManyAsync(IEnumerable<int> paymentIds)
    {
        HashSet<Id> ids = [];
        foreach (var id in paymentIds)
        {
            var idResult = Id.Create(id);
            if (idResult.IsFailure)
                return Result.Failure(ServiceErrors.Common.InvalidId);

            ids.Add(idResult.Value);
        }

        await _visitRepo.DeleteVisitPaymentsByIdsAsync(ids.ToImmutableList());

        return Result.Success();
    }
}