using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Prescription;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class PrescriptionService(
    IRepository<Prescription> prescriptionRepo,
    IRepository<Visit> visitRepository,
    IRepository<Patient> patientRepository,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<Prescription, PrescriptionResponseDto>> logger)
    : ServiceBase<Prescription, PrescriptionResponseDto>(prescriptionRepo, unitOfWork, logger)
    , IPrescriptionService
{
    public async Task<Result<int>> CreateAsync(
        PrescriptionRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("PrescriptionService.CreateAsync called");

        // Validate the DTO and get a valid Prescription entity
        var entityResult = ValidateDtoAndGetValidEntity(dto);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        // Ensure the foreign keys (PatientId and VisitId) exist in the database
        var ensureResult = await EnsureForeignKeysAsync(dto, cancellationToken);
        if (ensureResult.IsFailure)
        {
            return Result.Failure<int>(ensureResult.Error);
        }

        // Add the entity to the database and save changes
        await prescriptionRepo.AddAsync(entityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Prescription created successfully. {Id}", entityResult.Value.Id);

        return Result.Success(entityResult.Value.Id.Value);
    }

    public async Task<Result> UpdateAsync(
        int prescriptionId,
        PrescriptionRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("PrescriptionService.UpdateAsync called");

        // Validate the DTO and get a valid Prescription entity
        var entityResult = ValidateDtoAndGetValidEntity(dto);
        if (entityResult.IsFailure)
        {
            return Result.Failure(entityResult.Error);
        }

        // Ensure the foreign keys (PatientId and VisitId) exist in the database
        var ensureResult = await EnsureForeignKeysAsync(dto, cancellationToken);
        if (ensureResult.IsFailure)
        {
            return Result.Failure(ensureResult.Error);
        }

        // Retrieve the existing Prescription entity from the database
        var existingPrescriptionResult = await prescriptionRepo.GetByIdAsync(
            prescriptionId, cancellationToken);

        if (existingPrescriptionResult is null)
        {
            logger.LogInformation("Prescription not found. {Id}", prescriptionId);
            return Result.Failure(ServiceErrors.NotFound);
        }

        // Update the existing Prescription entity with new values
        var updateResult = existingPrescriptionResult.Update(
            entityResult.Value.PatientId,
            entityResult.Value.VisitId,
            entityResult.Value.Notes);

        if (updateResult.IsFailure)
        {
            logger.LogInformation("Failed to update Prescription. {Error}", updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Prescription updated successfully. {Id}", prescriptionId);

        return Result.Success();
    }


    private Result<Prescription> ValidateDtoAndGetValidEntity(
        PrescriptionRequestDto dto)
    {
        var patientIdResult = Id.Create(dto.PatientId);
        if (patientIdResult.IsFailure)
        {
            logger.LogInformation("Invalid patient ID provided. {Id}", dto.PatientId);
            return Result.Failure<Prescription>(patientIdResult.Error);
        }

        var visitIdResult = Id.Create(dto.VisitId);
        if (visitIdResult.IsFailure)
        {
            logger.LogInformation("Invalid visit ID provided. {Id}", dto.VisitId);
            return Result.Failure<Prescription>(visitIdResult.Error);
        }

        var entityResult = Prescription.Create(
            patientIdResult.Value,
            visitIdResult.Value,
            dto.Notes);

        if (entityResult.IsFailure)
        {
            logger.LogInformation("Failed to create Prescription entity. {Error}", entityResult.Error);
            return Result.Failure<Prescription>(entityResult.Error);
        }

        return entityResult.Value;
    }

    private async Task<Result> EnsureForeignKeysAsync(
        PrescriptionRequestDto dto,
        CancellationToken cancellationToken)
    {
        if (!await patientRepository.ExistsAsync(dto.PatientId, cancellationToken))
        {
            logger.LogInformation("Patient not found. {Id}", dto.PatientId);
            return Result.Failure(ServiceErrors.Prescription.PatientNotFound);
        }

        if (!await visitRepository.ExistsAsync(dto.VisitId, cancellationToken))
        {
            logger.LogInformation("Visit not found. {Id}", dto.VisitId);
            return Result.Failure(ServiceErrors.Prescription.VisitNotFound);
        }

        return Result.Success();
    }
}