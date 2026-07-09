using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.VisitToothNumber;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Id = Dental.Domain.ValueObjects.Id;

namespace Dental.Application.Services;

public sealed class VisitToothTreatmentService(
    IVisitToothTreatmentRepository visitToothTreatmentRepo,
    IRepository<Visit> visitRepo,
    IRepository<Service> serviceRepo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<VisitToothTreatment, VisitToothTreatmentResponseDto>> logger)
    : ServiceBase<VisitToothTreatment, VisitToothTreatmentResponseDto>(
            visitToothTreatmentRepo,
            unitOfWork,
            logger)
    , IVisitToothTreatmentService
{
    public async Task<Result<int>> CreateAsync(
        VisitToothTreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("VisitToothTreatmentService.CreateAsync is called. {dto}", dto);

        var validationResult = ValidateAndGetValidEntity(dto);
        if (validationResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit tooth treatment: {Error}", validationResult.Error);
            return Result.Failure<int>(validationResult.Error);
        }

        var ensureForeignKeysResult = await EnsureForeignKeys(dto, cancellationToken);
        if (ensureForeignKeysResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit tooth treatment: {Error}", ensureForeignKeysResult.Error);
            return Result.Failure<int>(ensureForeignKeysResult.Error);
        }

        await visitToothTreatmentRepo.AddAsync(validationResult.Value, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        logger.LogInformation("Visit tooth treatment created successfully with ID {Id}", validationResult.Value.Id);

        return validationResult.Value.Id;
    }

    public async Task<Result> UpdateAsync(
        int id,
        VisitToothTreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("VisitToothTreatmentService.UpdateAsync is called. {Id} {VisitToothTreatmentRequestDto}", id, dto);

        var validationResult = ValidateAndGetValidEntity(dto, id);
        if (validationResult.IsFailure)
        {
            logger.LogWarning("Failed to update visit tooth treatment: {Error}", validationResult.Error);
            return Result.Failure(validationResult.Error);
        }

        var ensureForeignKeysResult =
            await EnsureForeignKeys(dto, cancellationToken);
        if (ensureForeignKeysResult.IsFailure)
        {
            logger.LogWarning("Failed to update visit tooth treatment: {Error}", ensureForeignKeysResult.Error);
            return Result.Failure(ensureForeignKeysResult.Error);
        }

        var entity =
            await visitToothTreatmentRepo.GetByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            logger.LogWarning("Visit tooth treatment not found. {Id}", id);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var updateResult = entity.Update(
            validationResult.Value.ToothNumber,
            validationResult.Value.VisitId,
            validationResult.Value.ServiceId,
            validationResult.Value.Price,
            validationResult.Value.Notes);

        if (updateResult.IsFailure)
        {
            logger.LogWarning("Failed to update visit tooth treatment. {Error}", updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogInformation("Visit tooth treatment updated successfully. {Id}", id);

        return Result.Success();
    }


    private Result<VisitToothTreatment> ValidateAndGetValidEntity(
        VisitToothTreatmentRequestDto dto,
        int? id = null)
    {
        if (id <= 0)
        {
            logger.LogWarning("Invalid visit tooth treatment ID while updating. {Id}", id);
            return Result.Failure<VisitToothTreatment>(ServiceErrors.InvalidId);
        }

        var toothNumberResult = ToothNumber.Create(dto.ToothNumber);
        if (toothNumberResult.IsFailure)
        {
            logger.LogWarning("Invalid tooth number. {ToothNumber}", dto.ToothNumber);
            return Result.Failure<VisitToothTreatment>(toothNumberResult.Error);
        }

        var visitIdResult = Id.Create(dto.VisitId);
        if (visitIdResult.IsFailure)
        {
            logger.LogWarning("Invalid visit ID. {VisitId}", dto.VisitId);
            return Result.Failure<VisitToothTreatment>(visitIdResult.Error);
        }

        var serviceIdResult = Id.Create(dto.ServiceId);
        if (serviceIdResult.IsFailure)
        {
            logger.LogWarning("Invalid service ID. {ServiceId}", dto.ServiceId);
            return Result.Failure<VisitToothTreatment>(serviceIdResult.Error);
        }

        var priceResult = Money.Create(dto.Price);
        if (priceResult.IsFailure)
        {
            logger.LogWarning("Invalid price. {Price}", dto.Price);
            return Result.Failure<VisitToothTreatment>(priceResult.Error);
        }

        var visitToothTreatmentResult = VisitToothTreatment.Create(
            toothNumberResult.Value,
            visitIdResult.Value,
            serviceIdResult.Value,
            priceResult.Value,
            dto.Notes
        );

        if (visitToothTreatmentResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit tooth treatment." +
                              "{VisitToothTreatmentResult}", visitToothTreatmentResult);
            return Result.Failure<VisitToothTreatment>(visitToothTreatmentResult.Error);
        }

        return visitToothTreatmentResult.Value;
    }

    private async Task<Result> EnsureForeignKeys(
        VisitToothTreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        if (!await visitRepo.ExistsAsync(
                dto.VisitId,
                cancellationToken))
        {
            logger.LogWarning("Visit not found. {VisitId}", dto.VisitId);
            return Result.Failure(ServiceErrors.VisitToothTreatmentErrors.VisitNotFound);
        }


        if (!await serviceRepo.ExistsAsync(
                dto.ServiceId,
                cancellationToken))
        {
            logger.LogWarning("Service not found. {ServiceId}", dto.ServiceId);
            return Result.Failure(ServiceErrors.VisitToothTreatmentErrors.ServiceNotFound);
        }

        if (await visitToothTreatmentRepo.AreServiceIdAndVisitIdExists(
                dto.ServiceId,
                dto.VisitId))
        {
            logger.LogWarning(
                "Visit tooth treatment already exists for the given service and visit IDs.");
            return Result.Failure(ServiceErrors.VisitToothTreatmentErrors.AlreadyExists);
        }

        return Result.Success();
    }
}