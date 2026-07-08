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
        var firstNameResult = FirstName.Create(dto.FirstName);
        if (firstNameResult.IsFailure)
            return Result.Failure<int>(firstNameResult.Error);

        var lastNameResult = LastName.Create(dto.LastName);
        if (lastNameResult.IsFailure)
            return Result.Failure<int>(lastNameResult.Error);

        DateOfBirth? dateOfBirth = null;

        if (dto.DateOfBirth is not null)
        {
            var dateOfBirthResult = DateOfBirth.Create(dto.DateOfBirth.Value);
            if (dateOfBirthResult.IsFailure)
                return Result.Failure<int>(dateOfBirthResult.Error);

            dateOfBirth = dateOfBirthResult.Value;
        }

        PhoneNumber? phoneNumber = null;

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
        {
            var phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);
            if (phoneNumberResult.IsFailure)
                return Result.Failure<int>(phoneNumberResult.Error);

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
            return Result.Failure<int>(patientResult.Error);

        await repo.AddAsync(patientResult.Value, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success(patientResult.Value.Id);
    }

    public async Task<Result> UpdateAsync(
        int id,
        UpdatePatientDto dto,
        CancellationToken cancellationToken)
    {
        if (id <= 0)
            return Result.Failure(ServiceErrors.InvalidId);

        var patient = await repo.GetByIdAsync(id, cancellationToken);
        if (patient is null)
            return Result.Failure(ServiceErrors.NotFound);

        var firstNameResult = FirstName.Create(dto.FirstName);
        if (firstNameResult.IsFailure)
            return Result.Failure(firstNameResult.Error);

        var lastNameResult = LastName.Create(dto.LastName);
        if (lastNameResult.IsFailure)
            return Result.Failure(lastNameResult.Error);

        DateOfBirth? dateOfBirth = null;

        if (dto.DateOfBirth is not null)
        {
            var dateOfBirthResult = DateOfBirth.Create(dto.DateOfBirth.Value);

            if (dateOfBirthResult.IsFailure)
                return Result.Failure(dateOfBirthResult.Error);

            dateOfBirth = dateOfBirthResult.Value;
        }

        PhoneNumber? phoneNumber = null;

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
        {
            var phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);

            if (phoneNumberResult.IsFailure)
                return Result.Failure(phoneNumberResult.Error);

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
            return Result.Failure(updateResult.Error);

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}