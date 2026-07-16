using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.PrescriptionItem;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class PrescriptionItemService : IPrescriptionItemService
{
    private readonly IVisitRepository _visitRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PrescriptionItemService> _logger;

    public PrescriptionItemService(
        IVisitRepository visitRepository,
        IUnitOfWork unitOfWork,
        ILogger<PrescriptionItemService> logger)
    {
        _visitRepo = visitRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<PrescriptionItem>> CreateAsync(
        int visitId,
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("PrescriptionItemService.CreateAsync is called. {dto} {VisitId}", dto, visitId);

        // Validate the dto.VisitId
        var visitIdResult = Id.Create(visitId);
        if (visitIdResult.IsFailure)
        {
            _logger.LogWarning(
                "Cannot Create a PrescriptionItem due to invalid VisitId. {Id}", visitId);
            return Result.Failure<PrescriptionItem>(visitIdResult.Error);
        }

        var medicineFrequencyResult = MedicineFrequency.Create(
            dto.MedicineFrequency,
            dto.PeriodFrequency);
        if (medicineFrequencyResult.IsFailure)
        {
            _logger.LogWarning(
                "Cannot Create a PrescriptionItem due to invalid MedicineFrequency" +
                " or PeriodFrequency. {MedicineFrequency} {PeriodFrequency}",
                dto.MedicineFrequency,
                dto.PeriodFrequency);
            return Result.Failure<PrescriptionItem>(medicineFrequencyResult.Error);
        }

        // Get the visit by dto.VisitId
        var visit = await _visitRepo.GetByIdAsync(visitIdResult.Value);
        if (visit == null)
        {
            _logger.LogWarning("Visit not found. {Id}", visitIdResult.Value.Value);
            return Result.Failure<PrescriptionItem>(ServiceErrors.PrescriptionItem.VisitNotFound);
        }

        // Add the prescription item to the prescription throw the visit entity model
        var addPrescriptionItemResult = visit.AddPrescriptionItem(
            dto.MedicineName,
            dto.Dosage,
            medicineFrequencyResult.Value,
            dto.Instructions);
        if (addPrescriptionItemResult.IsFailure)
        {
            _logger.LogWarning("Failed to add PrescriptionItem due to domain business rules. {Error}",
                addPrescriptionItemResult.Error);
            return Result.Failure<PrescriptionItem>(addPrescriptionItemResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("PrescriptionItem created successfully.");

        return Result.Success(addPrescriptionItemResult.Value);
    }

    public async Task<Result> UpdateAsync(
        int id,
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "PrescriptionItemService.UpdateAsync is called. {Id} {Dto}", id, dto);

        var itemIdResult = Id.Create(id);
        if (itemIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid Id. {Id}", id);
            return Result.Failure(ServiceErrors.InvalidId);
        }

        var medicineFrequencyResult = MedicineFrequency.Create(dto.MedicineFrequency, dto.PeriodFrequency);
        if (medicineFrequencyResult.IsFailure)
        {
            _logger.LogWarning("Invalid MedicineFrequency of PeriodFrequency. {Error}", medicineFrequencyResult.Error);
            return Result.Failure(medicineFrequencyResult.Error);
        }

        var visit = await _visitRepo.GetByPrescriptionItemIdAsync(
            itemIdResult.Value, false, cancellationToken);
        if (visit == null)
        {
            _logger.LogWarning("PrescriptionItem not found. {Id}", id);
            return Result.Failure(ServiceErrors.PrescriptionItem.PrescriptionItemNotFound);
        }

        var updateItemResult = visit.UpdatePrescriptionItem(
            itemIdResult.Value,
            dto.MedicineName,
            dto.Dosage,
            medicineFrequencyResult.Value,
            dto.Instructions);
        if (updateItemResult.IsFailure)
        {
            _logger.LogWarning("Failed to update PrescriptionItem due to Domain business rules. {Error}", updateItemResult.Error);
            return Result.Failure(medicineFrequencyResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("PrescriptionItem updated successfully.");

        return Result.Success();
    }
}