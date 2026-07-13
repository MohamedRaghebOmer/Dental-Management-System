using Dental.Application.Abstractions;
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

public sealed class VisitTreatmentService(
    IVisitTreatmentsRepository visitTreatmentsRepo,
    IVisitRepository visitRepo,
    ITreatmentRepository serviceRepo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<VisitTreatment, VisitTreatmentResponseDto>> logger)
    : ServiceBase<VisitTreatment, VisitTreatmentResponseDto>(visitTreatmentsRepo,
            unitOfWork, logger)
    , IVisitTreatmentService
{
    public async Task<Result<int>> CreateAsync(
        VisitTreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("VisitToothTreatmentService.CreateAsync is called. {dto}", dto);

        var validationResult = await BuildEntityAndEnsureForeignKeys(dto, cancellationToken);
        if (validationResult.IsFailure)
        {
            return Result.Failure<int>(validationResult.Error);
        }

        await visitTreatmentsRepo.AddAsync(validationResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Visit tooth treatment created successfully with ID {Id}", validationResult.Value.Id);

        return validationResult.Value.Id.Value;
    }

    public async Task<Result<List<VisitTreatmentResponseDto>>> GetByVisitIdAsync(
        int visitId, 
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(
            "VisitToothTreatmentService.GetByVisitIdAsync is called. {VisitId}", visitId);

        if (visitId <= 0)
        {
            logger.LogWarning("Invalid visit ID. {VisitId}", visitId);
            return Result.Failure<List<VisitTreatmentResponseDto>>(ServiceErrors.InvalidId);
        }

        var entities = await visitTreatmentsRepo.GetByVisitIdAsync(visitId);
        if (!entities.Any())
        {
            logger.LogWarning(
                "There is no Visit Tooth Treatments not found for the given Visit Id.{VisitId}", visitId);
        }

        logger.LogInformation("Visit Tooth Treatments retrieved successfully. {Count} found.", entities.Count);
        return entities.Select(VisitTreatmentResponseDto.ToResponseDto).ToList();
    }

    public async Task<Result> UpdateAsync(
        int id,
        VisitTreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("VisitToothTreatmentService.UpdateAsync is called. {Id} {VisitToothTreatmentRequestDto}", id, dto);

        var validationResult = await BuildEntityAndEnsureForeignKeys(dto, cancellationToken, id);
        if (validationResult.IsFailure)
        {
            return Result.Failure(validationResult.Error);
        }

        var entity =
            await visitTreatmentsRepo.GetByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            logger.LogWarning("Visit tooth treatment not found. {Id}", id);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var updateResult = entity.Update(
            validationResult.Value.ToothNumber,
            validationResult.Value.VisitId,
            validationResult.Value.TreatmentId,
            validationResult.Value.Price,
            validationResult.Value.Notes);

        if (updateResult.IsFailure)
        {
            logger.LogWarning("Failed to update visit tooth treatment. {Error}", updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Visit tooth treatment updated successfully. {Id}", id);

        return Result.Success();
    }

    private async Task<Result<VisitTreatment>> BuildEntityAndEnsureForeignKeys(
        VisitTreatmentRequestDto dto,
        CancellationToken cancellationToken,
        int? id = null)
    {
        if (id <= 0)
        {
            logger.LogWarning("Invalid visit tooth treatment ID while updating. {Id}", id);
            return Result.Failure<VisitTreatment>(ServiceErrors.InvalidId);
        }

        var toothNumberResult = ToothNumber.Create(dto.ToothNumber);
        if (toothNumberResult.IsFailure)
        {
            logger.LogWarning("Invalid tooth number. {ToothNumber}", dto.ToothNumber);
            return Result.Failure<VisitTreatment>(toothNumberResult.Error);
        }

        var visitIdResult = Id.Create(dto.VisitId);
        if (visitIdResult.IsFailure)
        {
            logger.LogWarning("Invalid visit ID. {VisitId}", dto.VisitId);
            return Result.Failure<VisitTreatment>(visitIdResult.Error);
        }

        var serviceIdResult = Id.Create(dto.ServiceId);
        if (serviceIdResult.IsFailure)
        {
            logger.LogWarning("Invalid service ID. {ServiceId}", dto.ServiceId);
            return Result.Failure<VisitTreatment>(serviceIdResult.Error);
        }

        var priceResult = Money.Create(dto.Price);
        if (priceResult.IsFailure)
        {
            logger.LogWarning("Invalid price. {Price}", dto.Price);
            return Result.Failure<VisitTreatment>(priceResult.Error);
        }

        var visitToothTreatmentResult = VisitTreatment.Create(
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
            return Result.Failure<VisitTreatment>(visitToothTreatmentResult.Error);
        }

        var ensureForeignKeysResult = await EnsureForeignKeys(
            dto,
            id,
            cancellationToken);

        if (ensureForeignKeysResult.IsFailure)
        {
            return Result.Failure<VisitTreatment>(ensureForeignKeysResult.Error);
        }

        return visitToothTreatmentResult.Value;
    }

    private async Task<Result> EnsureForeignKeys(
        VisitTreatmentRequestDto dto,
        int? id = null,
        CancellationToken cancellationToken = default)
    {
        if (!await visitRepo.ExistsAsync(
                dto.VisitId,
                cancellationToken))
        {
            logger.LogWarning("Visit not found. {VisitId}", dto.VisitId);
            return Result.Failure(ServiceErrors.VisitTreatmentErrors.VisitNotFound);
        }


        if (!await serviceRepo.ExistsAsync(
                dto.ServiceId,
                cancellationToken))
        {
            logger.LogWarning("Service not found. {ServiceId}", dto.ServiceId);
            return Result.Failure(ServiceErrors.VisitTreatmentErrors.ServiceNotFound);
        }

        if (await visitTreatmentsRepo.ExistsByToothNumberAndServiceIdAndVisitId(
                dto.ToothNumber,
                dto.ServiceId,
                dto.VisitId,
                id,
                cancellationToken))
        {
            logger.LogWarning(
                "The visit tooth treatment already exists for the given tooth number, service, and visit IDs.");
            return Result.Failure(ServiceErrors.VisitTreatmentErrors.AlreadyExists);
        }

        return Result.Success();
    }
}