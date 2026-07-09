using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Patient;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public class PatientService(
    IRepository<Patient> repo,
    IUnitOfWork unitOfWork,
    ILogger<PatientService> logger) :
    ServiceBase<Patient, PatientResponseDto>(repo, unitOfWork, logger)
    , IPatientService
{
    public async Task<Result<int>> CreateAsync(
        CreatePatientDto dto,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("PatientService.CreateAsync is called. {dto}", dto);

        var firstNameResult = FirstName.Create(dto.FirstName);
        if (firstNameResult.IsFailure)
        {
            logger.LogWarning("Failed to create patient due to invalid first name. {FirstName}", dto.FirstName);
            return Result.Failure<int>(firstNameResult.Error);
        }


        var lastNameResult = LastName.Create(dto.LastName);
        if (lastNameResult.IsFailure)
        {
            logger.LogWarning("Failed to create patient due to invalid last name. {LastName}", dto.LastName);
            return Result.Failure<int>(lastNameResult.Error);
        }

        DateOfBirth? dateOfBirth = null;

        if (dto.DateOfBirth is not null)
        {
            var dateOfBirthResult = DateOfBirth.Create(dto.DateOfBirth.Value);
            if (dateOfBirthResult.IsFailure)
            {
                logger.LogWarning("Failed to create patient due to invalid date of birth. {DateOfBirth}", dto.DateOfBirth);
                return Result.Failure<int>(dateOfBirthResult.Error);
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
                return Result.Failure<int>(phoneNumberResult.Error);
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
            return Result.Failure<int>(patientResult.Error);
        }


        await repo.AddAsync(patientResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Patient created successfully. {PatientId}", patientResult.Value.Id);

        return Result.Success(patientResult.Value.Id);
    }

    public async Task<Result> UpdateAsync(
        int id,
        UpdatePatientDto dto,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("PatientService.UpdateAsync is called. {PatientId} {UpdatePatientDto}", id, dto);

        if (id <= 0)
        {
            logger.LogWarning("Invalid patient ID. {Id}", id);
            return Result.Failure(ServiceErrors.InvalidId);
        }


        var patient = await repo.GetByIdAsync(id, cancellationToken);
        if (patient is null)
        {
            logger.LogWarning("Patient not found. {Id}", id);
            return Result.Failure(ServiceErrors.NotFound);
        }


        var firstNameResult = FirstName.Create(dto.FirstName);
        if (firstNameResult.IsFailure)
        {
            logger.LogWarning("Failed to update patient due to invalid first name. {FirstName}", dto.FirstName);
            return Result.Failure(firstNameResult.Error);
        }


        var lastNameResult = LastName.Create(dto.LastName);
        if (lastNameResult.IsFailure)
        {
            logger.LogWarning("Failed to update patient due to invalid last name. {LastName}", dto.LastName);
            return Result.Failure(lastNameResult.Error);
        }


        DateOfBirth? dateOfBirth = null;

        if (dto.DateOfBirth is not null)
        {
            var dateOfBirthResult = DateOfBirth.Create(dto.DateOfBirth.Value);

            if (dateOfBirthResult.IsFailure)
            {
                logger.LogWarning("Failed to update patient due to invalid date of birth. {DateOfBirth}", dto.DateOfBirth);
                return Result.Failure(dateOfBirthResult.Error);
            }

            dateOfBirth = dateOfBirthResult.Value;
        }

        PhoneNumber? phoneNumber = null;

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
        {
            var phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);

            if (phoneNumberResult.IsFailure)
            {
                logger.LogWarning("Failed to update patient due to invalid phone number. {PhoneNumber}", dto.PhoneNumber);
                return Result.Failure(phoneNumberResult.Error);
            }

            phoneNumber = phoneNumberResult.Value;
        }

        var updateResult = patient.Update(
            firstNameResult.Value,
            lastNameResult.Value,
            dateOfBirth,
            dto.Gender,
            phoneNumber,
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
}