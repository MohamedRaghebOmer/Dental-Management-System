using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.VisitTreatments;
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
       CreateVisitTreatmentDto dto,
       CancellationToken cancellationToken = default)
    {
        Result<ToothNumber>? toothNumberResult = null;
        if (dto.ToothNumber.HasValue)
        {
            toothNumberResult = ToothNumber.Create(dto.ToothNumber.Value);
            if (toothNumberResult.IsFailure)
            {
                _logger.LogWarning("Invalid tooth number. {ToothNumber}", dto.ToothNumber);
                return Result.Failure<int>(toothNumberResult.Error);
            }
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
            _logger.LogWarning("Invalid service ID. {TreatmentId}", dto.TreatmentId);
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
            treatmentId: treatmentIdResult.Value,
            toothNumber: toothNumberResult?.Value,
            treatmentPrice: price,
            notes: dto.Notes,
            count: dto.Count);

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
        CreateVisitTreatmentDto[] dtos,
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
            Result<ToothNumber>? toothNumberResult = null;
            if (dto.ToothNumber.HasValue)
            {
                toothNumberResult = ToothNumber.Create(dto.ToothNumber.Value);
                if (toothNumberResult.IsFailure)
                {
                    _logger.LogWarning("Invalid tooth number. {ToothNumber}", dto.ToothNumber);
                    return Result.Failure<int>(toothNumberResult.Error);
                }
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
                treatmentId: treatmentIdResult.Value,
                toothNumber: toothNumberResult?.Value,
                count: dto.Count,
                treatmentPrice: Money.FromDatabase(price),
                notes: dto.Notes);

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

    /// <summary>
    /// Adds new VisitTreatments, updates existing VisitTreatments,
    /// and deletes the specified VisitTreatments atomically.
    /// </summary>
    /// <param name="newVisitTreatments">The VisitTreatments to add.</param>
    /// <param name="updatedVisitTreatments">The VisitTreatments to update.</param>
    /// <param name="deletedVisitTreatments">The IDs of the VisitTreatments to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A successful result when all operations are completed successfully;
    /// otherwise, a failure result.
    /// </returns>
    public async Task<Result> SyncVisitTreatmentsAsync(
        CreateVisitTreatmentDto[] newVisitTreatments,
        UpdateVisitTreatmentDto[] updatedVisitTreatments,
        HashSet<int> deletedVisitTreatments,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "Syncing visit treatments. New: {NewCount}, Updated: {UpdatedCount}, Deleted: {DeletedCount}",
            newVisitTreatments.Length,
            updatedVisitTreatments.Length,
            deletedVisitTreatments.Count);

        // ====================== Validate new VisitTreatments ======================

        var validatedNewVisitTreatments =
            new List<(CreateVisitTreatmentDto Dto, Id VisitId, Id TreatmentId, ToothNumber? ToothNumber)>();

        var newVisitIds = new HashSet<Id>();
        var newTreatmentIds = new HashSet<Id>();

        foreach (var dto in newVisitTreatments)
        {
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

            if (dto.Count <= 0)
            {
                _logger.LogWarning(
                    "Invalid VisitTreatment count. {Count}",
                    dto.Count);

                return Result.Failure(
                    ServiceErrors.VisitTreatment.InvalidCount);
            }

            ToothNumber? toothNumber = null;

            if (dto.ToothNumber.HasValue)
            {
                var toothNumberResult =
                    ToothNumber.Create(dto.ToothNumber.Value);

                if (toothNumberResult.IsFailure)
                {
                    _logger.LogWarning(
                        "Invalid tooth number. {ToothNumber}",
                        dto.ToothNumber);

                    return Result.Failure(
                        toothNumberResult.Error);
                }

                toothNumber = toothNumberResult.Value;
            }

            var visitId = visitIdResult.Value;
            var treatmentId = treatmentIdResult.Value;

            validatedNewVisitTreatments.Add(
                (dto, visitId, treatmentId, toothNumber));

            newVisitIds.Add(visitId);
            newTreatmentIds.Add(treatmentId);
        }

        // ====================== Validate updated VisitTreatments ======================

        var validatedUpdatedVisitTreatments =
            new List<(UpdateVisitTreatmentDto Dto, Id VisitTreatmentId, Id TreatmentId, ToothNumber? ToothNumber)>();

        var updatedVisitTreatmentIds = new HashSet<Id>();
        var updatedTreatmentIds = new HashSet<Id>();

        foreach (var dto in updatedVisitTreatments)
        {
            var visitTreatmentIdResult = Id.Create(dto.Id);

            if (visitTreatmentIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "Invalid VisitTreatment ID. {VisitTreatmentId}",
                    dto.Id);

                return Result.Failure(
                    visitTreatmentIdResult.Error);
            }

            var treatmentIdResult = Id.Create(dto.TreatmentId);

            if (treatmentIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "Invalid Treatment ID. {TreatmentId}",
                    dto.TreatmentId);

                return Result.Failure(
                    treatmentIdResult.Error);
            }

            if (dto.Count <= 0)
            {
                _logger.LogWarning(
                    "Invalid VisitTreatment count. {Count}",
                    dto.Count);

                return Result.Failure(
                    ServiceErrors.VisitTreatment.InvalidCount);
            }

            ToothNumber? toothNumber = null;

            if (dto.ToothNumber.HasValue)
            {
                var toothNumberResult =
                    ToothNumber.Create(dto.ToothNumber.Value);

                if (toothNumberResult.IsFailure)
                {
                    _logger.LogWarning(
                        "Invalid tooth number. {ToothNumber}",
                        dto.ToothNumber);

                    return Result.Failure(
                        toothNumberResult.Error);
                }

                toothNumber = toothNumberResult.Value;
            }

            var visitTreatmentId = visitTreatmentIdResult.Value;
            var treatmentId = treatmentIdResult.Value;

            validatedUpdatedVisitTreatments.Add(
                (dto, visitTreatmentId, treatmentId, toothNumber));

            updatedVisitTreatmentIds.Add(visitTreatmentId);
            updatedTreatmentIds.Add(treatmentId);
        }

        // ====================== Validate deleted VisitTreatments ======================

        var deletedVisitTreatmentIds = new HashSet<Id>();

        foreach (var id in deletedVisitTreatments)
        {
            var idResult = Id.Create(id);

            if (idResult.IsFailure)
            {
                _logger.LogWarning(
                    "Invalid VisitTreatment ID. {VisitTreatmentId}",
                    id);

                return Result.Failure(
                    idResult.Error);
            }

            deletedVisitTreatmentIds.Add(idResult.Value);
        }

        // A VisitTreatment cannot be updated and deleted
        // in the same request.
        if (deletedVisitTreatments.Overlaps(
            updatedVisitTreatmentIds.Select(id => id.Value)))
        {
            _logger.LogWarning(
                "A VisitTreatment was requested for both update and delete.");

            return Result.Failure(
                ServiceErrors.VisitTreatment.UpdateAndDeleteConflict);
        }

        // ====================== Transaction ======================

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            // ============================================================
            // Load all required data BEFORE modifying any Aggregate Root.
            //
            // This is important because adding a new VisitTreatment before
            // another query can cause EF Core relationship fix-up to include
            // the unsaved entity in Visit.VisitTreatments with Id == null.
            // ============================================================

            // ====================== Load update aggregates ======================

            Dictionary<int, Visit> visitsToUpdate = [];

            if (updatedVisitTreatmentIds.Count > 0)
            {
                visitsToUpdate =
                    await _visitRepo.GetByTreatmentIdsAsync(
                        updatedVisitTreatmentIds,
                        cancellationToken);
            }

            // ====================== Load all required Treatment prices ======================
            //
            // For new treatments we need the price.
            // For updated treatments we only use this query to verify that
            // the new TreatmentId actually exists.

            var allTreatmentIds = new HashSet<Id>(newTreatmentIds);

            allTreatmentIds.UnionWith(updatedTreatmentIds);

            Dictionary<int, Money> treatmentPrices = [];

            if (allTreatmentIds.Count > 0)
            {
                treatmentPrices =
                    await _visitRepo.GetTreatmentsPricesAsync(
                        allTreatmentIds,
                        cancellationToken);
            }

            // ====================== Validate update targets ======================

            var visitByVisitTreatmentId = new Dictionary<int, Visit>();

            foreach (var visit in visitsToUpdate.Values)
            {
                foreach (var visitTreatment in visit.VisitTreatments)
                {
                    /*
                     * These VisitTreatments came from the database because
                     * no new VisitTreatment has been added yet.
                     *
                     * Therefore Id must exist.
                     */
                    if (visitTreatment.Id is null)
                    {
                        throw new InvalidOperationException(
                            "A persisted VisitTreatment was loaded without an ID.");
                    }

                    visitByVisitTreatmentId.Add(
                        visitTreatment.Id.Value,
                        visit);
                }
            }

            foreach (var item in validatedUpdatedVisitTreatments)
            {
                if (!visitByVisitTreatmentId.ContainsKey(
                        item.VisitTreatmentId.Value))
                {
                    _logger.LogWarning(
                        "VisitTreatment not found. {VisitTreatmentId}",
                        item.Dto.Id);

                    await _unitOfWork.RollbackTransactionAsync(
                        CancellationToken.None);

                    return Result.Failure(
                        ServiceErrors.VisitTreatment.NotFound);
                }

                if (!treatmentPrices.ContainsKey(
                        item.TreatmentId.Value))
                {
                    _logger.LogWarning(
                        "Treatment not found. {TreatmentId}",
                        item.Dto.TreatmentId);

                    await _unitOfWork.RollbackTransactionAsync(
                        CancellationToken.None);

                    return Result.Failure(
                        ServiceErrors.VisitTreatment.TreatmentNotFound);
                }
            }

            // ====================== Load visits required for new VisitTreatments ======================

            var visitsById =
                visitsToUpdate.Values
                    .ToDictionary(
                        visit => visit.Id!.Value,
                        visit => visit);

            var newVisitIdsToLoad =
                newVisitIds
                    .Where(id => !visitsById.ContainsKey(id.Value))
                    .ToHashSet();

            if (newVisitIdsToLoad.Count > 0)
            {
                var newVisits =
                    await _visitRepo.GetByIdsAsync(
                        newVisitIdsToLoad,
                        cancellationToken,
                        v => v.VisitTreatments);

                foreach (var pair in newVisits)
                {
                    visitsById.Add(
                        pair.Key,
                        pair.Value);
                }
            }

            // ====================== Validate new VisitTreatments ======================

            foreach (var item in validatedNewVisitTreatments)
            {
                if (!visitsById.ContainsKey(
                        item.VisitId.Value))
                {
                    _logger.LogWarning(
                        "Visit not found. {VisitId}",
                        item.Dto.VisitId);

                    await _unitOfWork.RollbackTransactionAsync(
                        CancellationToken.None);

                    return Result.Failure(
                        ServiceErrors.VisitTreatment.VisitNotFound);
                }

                if (!treatmentPrices.ContainsKey(
                        item.TreatmentId.Value))
                {
                    _logger.LogWarning(
                        "Treatment not found. {TreatmentId}",
                        item.Dto.TreatmentId);

                    await _unitOfWork.RollbackTransactionAsync(
                        CancellationToken.None);

                    return Result.Failure(
                        ServiceErrors.VisitTreatment.TreatmentNotFound);
                }
            }

            // ============================================================
            // At this point:
            //
            // - All input has been validated.
            // - All required Visits exist.
            // - All required Treatments exist.
            // - All update targets exist.
            // - No new VisitTreatment has been added yet.
            //
            // Now we can safely modify the Aggregate Roots.
            // ============================================================

            // ====================== Update existing VisitTreatments ======================

            foreach (var item in validatedUpdatedVisitTreatments)
            {
                var visit =
                    visitByVisitTreatmentId[
                        item.VisitTreatmentId.Value];

                var updateResult =
                    visit.UpdateVisitTreatment(
                        visitTreatmentId: item.VisitTreatmentId,
                        treatmentId: item.TreatmentId,
                        toothNumber: item.ToothNumber,
                        count: item.Dto.Count,
                        notes: item.Dto.Notes);

                if (updateResult.IsFailure)
                {
                    _logger.LogWarning(
                        "Failed to update VisitTreatment. {VisitTreatmentId}",
                        item.Dto.Id);

                    await _unitOfWork.RollbackTransactionAsync(
                        CancellationToken.None);

                    return Result.Failure(
                        updateResult.Error);
                }
            }

            // ====================== Add new VisitTreatments ======================

            foreach (var item in validatedNewVisitTreatments)
            {
                var visit =
                    visitsById[item.VisitId.Value];

                var treatmentPrice =
                    treatmentPrices[item.TreatmentId.Value];

                var addResult =
                    visit.AddVisitTreatment(
                        treatmentId: item.TreatmentId,
                        toothNumber: item.ToothNumber,
                        count: item.Dto.Count,
                        treatmentPrice: treatmentPrice,
                        notes: item.Dto.Notes);

                if (addResult.IsFailure)
                {
                    _logger.LogWarning(
                        "Failed to add VisitTreatment. VisitId: {VisitId}, TreatmentId: {TreatmentId}",
                        item.Dto.VisitId,
                        item.Dto.TreatmentId);

                    await _unitOfWork.RollbackTransactionAsync(
                        CancellationToken.None);

                    return Result.Failure(
                        addResult.Error);
                }
            }

            // ====================== Persist changes ======================

            await _unitOfWork.SaveChangesAsync(
                cancellationToken);

            // ExecuteDelete is intentionally done after SaveChanges
            // because it bypasses EF Core change tracking.
            if (deletedVisitTreatmentIds.Count > 0)
            {
                await _visitRepo.DeleteManyVisitTreatments(
                    deletedVisitTreatmentIds,
                    cancellationToken);
            }

            await _unitOfWork.CommitTransactionAsync(
                cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync(
                CancellationToken.None);

            _logger.LogError(
                ex,
                "An error occurred while syncing VisitTreatments.");

            throw;
        }
    }
}