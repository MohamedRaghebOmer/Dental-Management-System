using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.VisitToothNumber;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Id = Dental.Domain.ValueObjects.Id;

namespace Dental.Application.Services;

public sealed class VisitTreatmentService
    : IVisitTreatmentService
{
    private readonly IVisitRepository _visitRepo;
    private readonly ITreatmentRepository _treatmentRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VisitTreatmentService> _logger;

    public VisitTreatmentService(
        IVisitRepository visitRepo,
        ITreatmentRepository serviceRepo,
        IUnitOfWork unitOfWork,
        ILogger<VisitTreatmentService> logger)
    {
        _visitRepo = visitRepo;
        _treatmentRepo = serviceRepo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }


    public async Task<Result<int>> CreateAsync(
       VisitTreatmentRequestDto dto,
       CancellationToken cancellationToken = default)
    {
        var toothNumberResult = ToothNumber.Create(dto.ToothNumber);
        if (toothNumberResult.IsFailure)
        {
            _logger.LogWarning("Invalid tooth number. {ToothNumber}", dto.ToothNumber);
            return Result.Failure<int>(toothNumberResult.Error);
        }

        var visitIdResult = Id.Create(dto.VisitId);
        if (visitIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid visit ID. {VisitId}", dto.VisitId);
            return Result.Failure<int>(visitIdResult.Error);
        }

        var treatmentIdResult = Id.Create(dto.TreatmentId);
        if (treatmentIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid service ID. {ServiceId}", dto.TreatmentId);
            return Result.Failure<int>(treatmentIdResult.Error);
        }

        var visit = await _visitRepo.GetByIdAsync(visitIdResult.Value, cancellationToken);
        if (visit is null)
        {
            _logger.LogWarning("Visit not found. {Id}", visitIdResult.Value);
            return Result.Failure<int>(ServiceErrors.VisitTreatment.VisitNotFound);
        }

        var price = await _treatmentRepo.GetPriceByIdAsync(treatmentIdResult.Value, cancellationToken);
        if (price is null)
        {
            _logger.LogWarning("Treatment not found. {Id}", treatmentIdResult.Value);
            return Result.Failure<int>
                    (ServiceErrors.VisitTreatment.TreatmentNotFound);
        }

        var visitToothTreatmentResult = visit.AddVisitTreatment(
            toothNumberResult.Value,
            treatmentIdResult.Value,
            price,
            dto.Notes);

        if (visitToothTreatmentResult.IsFailure)
        {
            _logger.LogWarning(
                    "Failed to create VisitTreatment. {Error}",
                    visitToothTreatmentResult.Error);
            return Result.Failure<int>(visitToothTreatmentResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return visitToothTreatmentResult.Value.Id.Value;
    }

    public async Task<Result> CreateManyAsync(
        VisitTreatmentRequestDto[] dtos,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "VisitTreatmentService.CreateManyAsync is called. {DTOs}",
            dtos);

        if (dtos.Length == 0)
            return Result.Success();

        var visitIds = new HashSet<Id>();
        var treatmentIds = new HashSet<Id>();

        foreach (var dto in dtos)
        {
            var visitIdResult = Id.Create(dto.VisitId);
            if (visitIdResult.IsFailure)
            {
                _logger.LogWarning("Invalid Visit Id. {Id} {Error}", dto.VisitId, visitIdResult.Error);
                return Result.Failure(visitIdResult.Error);
            }
            visitIds.Add(visitIdResult.Value);

            var treatmentIdResult = Id.Create(dto.TreatmentId);
            if (treatmentIdResult.IsFailure)
            {
                _logger.LogWarning("Invalid Treatment Id. {Id} {Error}", dto.TreatmentId, treatmentIdResult.Error);
                return Result.Failure(treatmentIdResult.Error);
            }
            treatmentIds.Add(treatmentIdResult.Value);
        }

        var visits = await _visitRepo.GetByIdsAsync(
            visitIds,
            cancellationToken);

        var treatmentPrices = await _treatmentRepo.GetPricesByIdsAsync(
            treatmentIds,
            cancellationToken);

        foreach (var dto in dtos)
        {
            var toothNumberResult = ToothNumber.Create(dto.ToothNumber);
            if (toothNumberResult.IsFailure)
            {
                _logger.LogWarning(
                    "Invalid tooth number. {ToothNumber}",
                    dto.ToothNumber);

                return Result.Failure(toothNumberResult.Error);
            }

            var visitIdResult = Id.Create(dto.VisitId);
            if (visitIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "Invalid Visit ID. {VisitId}",
                    dto.VisitId);

                return Result.Failure(visitIdResult.Error);
            }

            var treatmentIdResult = Id.Create(dto.TreatmentId);
            if (treatmentIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "Invalid Treatment ID. {TreatmentId}",
                    dto.TreatmentId);

                return Result.Failure(treatmentIdResult.Error);
            }

            if (!visits.TryGetValue(dto.VisitId, out var visit))
            {
                _logger.LogWarning(
                    "Visit not found. {VisitId}",
                    dto.VisitId);

                return Result.Failure(ServiceErrors.VisitTreatment.VisitNotFound);
            }

            if (!treatmentPrices.TryGetValue(dto.TreatmentId, out var price))
            {
                _logger.LogWarning(
                    "Treatment not found. {TreatmentId}",
                    dto.TreatmentId);

                return Result.Failure(ServiceErrors.VisitTreatment.TreatmentNotFound);
            }

            var addResult = visit.AddVisitTreatment(
                toothNumberResult.Value,
                treatmentIdResult.Value,
                Money.FromDatabase(price),
                dto.Notes);

            if (addResult.IsFailure)
            {
                _logger.LogWarning(
                    "Failed to add VisitTreatment. {Error}",
                    addResult.Error);

                return Result.Failure(addResult.Error);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation(
            "Successfully created {Count} VisitTreatments.",
            dtos.Length);

        return Result.Success();
    }

    public async Task<Result> SetAllVisitTreatmentsAsync(
        int visitId,
        VisitTreatmentRequestDto[] dtos,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "VisitTreatmentService.SetAllVisitTreatmentsAsync is called. {VisitId} {DTOs}",
            visitId, dtos);

        var visitIdResult = Id.Create(visitId);
        if (visitIdResult.IsFailure)
        {
            _logger.LogWarning(
                "Invalid Visit ID. {VisitId} {Error}",
                visitId,
                visitIdResult.Error);

            return Result.Failure(visitIdResult.Error);
        }

        var treatmentPrices =
            await _treatmentRepo.GetAllIdsAndPricesAsync(cancellationToken);

        var validatedTreatments = new List<(ToothNumber ToothNumber, Id TreatmentId, Money Price, string? Notes)>();

        foreach (var dto in dtos)
        {
            var toothNumberResult = ToothNumber.Create(dto.ToothNumber);
            if (toothNumberResult.IsFailure)
            {
                _logger.LogWarning(
                    "Invalid tooth number. {ToothNumber}",
                    dto.ToothNumber);

                return Result.Failure(toothNumberResult.Error);
            }

            var treatmentIdResult = Id.Create(dto.TreatmentId);
            if (treatmentIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "Invalid Treatment ID. {TreatmentId}",
                    dto.TreatmentId);

                return Result.Failure(treatmentIdResult.Error);
            }

            if (!treatmentPrices.TryGetValue(dto.TreatmentId, out var price))
            {
                _logger.LogWarning(
                    "Treatment not found. {TreatmentId}",
                    dto.TreatmentId);

                return Result.Failure(ServiceErrors.VisitTreatment.TreatmentNotFound);
            }

            validatedTreatments.Add((
                toothNumberResult.Value,
                treatmentIdResult.Value,
                Money.FromDatabase(price),
                dto.Notes));
        }

        await _visitRepo.DeleteAllVisitTreatmentsBelongToVisitAsync(
            visitIdResult.Value,
            cancellationToken);

        var visit = await _visitRepo.GetByIdAsync(visitIdResult.Value, cancellationToken);
        if (visit is null)
        {
            _logger.LogWarning("Visit not found. {VisitId}", visitId);

            return Result.Failure(ServiceErrors.VisitTreatment.VisitNotFound);
        }

        foreach (var treatment in validatedTreatments)
        {
            var addResult = visit.AddVisitTreatment(
                treatment.ToothNumber,
                treatment.TreatmentId,
                treatment.Price,
                treatment.Notes);

            if (addResult.IsFailure)
            {
                _logger.LogWarning(
                    "Failed to add VisitTreatment. {Error}",
                    addResult.Error);

                return Result.Failure(addResult.Error);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation(
            "VisitTreatments were successfully replaced. {VisitId}",
            visitId);

        return Result.Success();
    }
}