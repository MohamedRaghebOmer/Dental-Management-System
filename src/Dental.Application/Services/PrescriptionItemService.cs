using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.PrescriptionItem;
using Dental.Application.Errors;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class PrescriptionItemService(
    IRepository<Domain.Entities.PrescriptionItem> prescriptionItemRepo,
    IRepository<Domain.Entities.Prescription> prescriptionRepo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<Domain.Entities.PrescriptionItem,
        PrescriptionItemResponseDto>> logger)
    : ServiceBase<Domain.Entities.PrescriptionItem,
        PrescriptionItemResponseDto>(prescriptionItemRepo, unitOfWork, logger),
        IPrescriptionItemService
{
    public async Task<Result<int>> CreateAsync(
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("PrescriptionItemService.CreateAsync is called. {Dto}", dto);

        // Validate the DTO and get a valid entity
        var validEntityResult = BuildEntity(dto);
        if (validEntityResult.IsFailure)
        {
            return Result.Failure<int>(validEntityResult.Error);
        }

        // Ensure foreign keys exist
        var foreignKeysResult = await EnsureForeignKeysAsync(dto, cancellationToken);
        if (foreignKeysResult.IsFailure)
        {
            return Result.Failure<int>(foreignKeysResult.Error);
        }

        // Add the entity to the repository
        await prescriptionItemRepo.AddAsync(validEntityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation(
            "PrescriptionItem {Id} created successfully.",
            validEntityResult.Value.Id);

        return Result.Success(validEntityResult.Value.Id);
    }

    public async Task<Result> UpdateAsync(
        int id,
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(
            "PrescriptionItemService.UpdateAsync is called. {Id} {Dto}", id, dto);

        // Validate the DTO and get a valid entity
        var validEntityResult = BuildEntity(dto);
        if (validEntityResult.IsFailure)
        {
            return Result.Failure(validEntityResult.Error);
        }

        // Ensure foreign keys exist
        var foreignKeysResult = await EnsureForeignKeysAsync(dto, cancellationToken);
        if (foreignKeysResult.IsFailure)
        {
            return Result.Failure(foreignKeysResult.Error);
        }

        // Get the entity from the database
        var entity =
            await prescriptionItemRepo.GetByIdAsync(id, cancellationToken);
        if (entity is null)
        {
            logger.LogWarning("PrescriptionItem not found. {Id}", id);
            return Result.Failure(ServiceErrors.PrescriptionItem.PrescriptionItemNotFound);
        }

        // Update the entity
        var updateResult = entity.Update(
            validEntityResult.Value.PrescriptionId,
            validEntityResult.Value.MedicineName,
            validEntityResult.Value.Dosage,
            validEntityResult.Value.MedicineFrequency,
            validEntityResult.Value.Instructions);
        if (updateResult.IsFailure)
        {
            logger.LogWarning(
                "Failed to update PrescriptionItem {Id}. {Error}",
                id,
                updateResult.Error); return Result.Failure(updateResult.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation(
            "PrescriptionItem {Id} updated successfully.",
            id);

        return Result.Success();
    }


    private async Task<Result> EnsureForeignKeysAsync(
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        if (!await prescriptionRepo.ExistsAsync(dto.PrescriptionId, cancellationToken))
        {
            logger.LogWarning("Prescription not found. {Id}", dto.PrescriptionId);
            return Result.Failure(ServiceErrors.PrescriptionItem.PrescriptionNotFound);
        }

        return Result.Success();
    }

    private Result<Domain.Entities.PrescriptionItem> BuildEntity(
        PrescriptionItemRequestDto dto)
    {
        var prescriptionIdResult = Id.Create(dto.PrescriptionId);
        if (prescriptionIdResult.IsFailure)
        {
            logger.LogWarning(
                "Cannot Create a PrescriptionItem due to invalid PrescriptionId. {Id}", dto.PrescriptionId);
            return Result.Failure<Domain.Entities.PrescriptionItem>(prescriptionIdResult.Error);
        }

        var medicineFrequencyResult = MedicineFrequency.Create(
            dto.MedicineFrequency,
            dto.PeriodFrequency);
        if (medicineFrequencyResult.IsFailure)
        {
            logger.LogWarning(
                "Cannot Create a PrescriptionItem due to invalid MedicineFrequency or PeriodFrequency. {MedicineFrequency} {PeriodFrequency}",
                dto.MedicineFrequency,
                dto.PeriodFrequency);
            return Result.Failure<Domain.Entities.PrescriptionItem>(medicineFrequencyResult.Error);
        }

        var entityResult = Domain.Entities.PrescriptionItem.Create(
            prescriptionIdResult.Value,
            dto.MedicineName,
            dto.Dosage,
            medicineFrequencyResult.Value,
            dto.Instructions);

        if (entityResult.IsFailure)
        {
            logger.LogWarning(
                "Cannot Create a PrescriptionItem due to invalid data. {Error}",
                entityResult.Error);
            return Result.Failure<Domain.Entities.PrescriptionItem>(entityResult.Error);
        }

        return entityResult.Value;
    }
}