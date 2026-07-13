using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Patient;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public class PatientService(
    IPatientRepository repo,
    IUnitOfWork unitOfWork,
    ILogger<PatientService> logger) :
    ServiceBase<Patient, PatientResponseDto>(repo, unitOfWork, logger)
    , IPatientService
{
    public async Task<Result<int>> CreateAsync(
        PatientRequestDto dto,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("PatientService.CreateAsync is called. {dto}", dto);

        var entityResult = BuildEntity(dto);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        await repo.AddAsync(entityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Patient created successfully. {PatientId}", entityResult.Value.Id);

        return Result.Success(entityResult.Value.Id.Value);
    }

    public async Task<Result> UpdateAsync(
        int id,
        PatientRequestDto dto,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "PatientService.UpdateAsync is called. {PatientId} {UpdatePatientDto}",
            id, dto);

        var buildEntityResult = BuildEntity(dto, id);
        if (buildEntityResult.IsFailure)
        {
            return Result.Failure(buildEntityResult.Error);
        }

        var patient = await repo.GetByIdAsync(id, cancellationToken);
        if (patient is null)
        {
            logger.LogWarning("Patient not found. {Id}", id);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var updateResult = patient.Update(
            buildEntityResult.Value.FirstName,
            buildEntityResult.Value.LastName,
            buildEntityResult.Value.DateOfBirth,
            dto.Gender,
            buildEntityResult.Value.PhoneNumber,
            dto.Address);

        if (updateResult.IsFailure)
        {
            logger.LogWarning("Failed to update patient due to invalid patient data. {Error}", updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Patient updated successfully. {PatientId}", patient.Id);

        return Result.Success();
    }

    private Result<Patient> BuildEntity(PatientRequestDto dto, int? id = null)
    {
        if (id <= 0)
        {
            logger.LogWarning("Invalid patient ID. {Id}", id);
            return Result.Failure<Patient>(ServiceErrors.InvalidId);

        }

        var firstNameResult = FirstName.Create(dto.FirstName);
        if (firstNameResult.IsFailure)
        {
            logger.LogWarning("Failed to create patient due to invalid first name. {FirstName}", dto.FirstName);
            return Result.Failure<Patient>(firstNameResult.Error);
        }

        var lastNameResult = LastName.Create(dto.LastName);
        if (lastNameResult.IsFailure)
        {
            logger.LogWarning("Failed to create patient due to invalid last name. {LastName}", dto.LastName);
            return Result.Failure<Patient>(lastNameResult.Error);
        }

        DateOfBirth? dateOfBirth = null;

        if (dto.DateOfBirth is not null)
        {
            var dateOfBirthResult = DateOfBirth.Create(dto.DateOfBirth.Value);
            if (dateOfBirthResult.IsFailure)
            {
                logger.LogWarning("Failed to create patient due to invalid date of birth. {DateOfBirth}", dto.DateOfBirth);
                return Result.Failure<Patient>(dateOfBirthResult.Error);
            }

            dateOfBirth = dateOfBirthResult.Value;
        }

        PhoneNumber? phoneNumber = null;

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
        {
            var phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);
            if (phoneNumberResult.IsFailure)
            {
                logger.LogWarning("Failed to create patient due to invalid phone number. {PhoneNumber}", dto.PhoneNumber);
                return Result.Failure<Patient>(phoneNumberResult.Error);
            }


            phoneNumber = phoneNumberResult.Value;
        }

        var patientResult = Patient.Create(
            firstNameResult.Value,
            lastNameResult.Value,
            dateOfBirth,
            dto.Gender,
            phoneNumber,
            dto.Address);

        if (patientResult.IsFailure)
        {
            logger.LogWarning("Failed to create patient due to invalid patient data. {Error}", patientResult.Error);
            return Result.Failure<Patient>(patientResult.Error);
        }

        return Result.Success(patientResult.Value);
    }
}