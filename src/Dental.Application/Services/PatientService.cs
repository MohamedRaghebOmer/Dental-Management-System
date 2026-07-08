using Dental.Application.Abstractions;
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
{
    public async Task<Result<int>> CreatePatient(CreatePatientDto dto)
    {
        var firstNameResult = FirstName.Create(dto.FirstName);
        if (firstNameResult.IsFailure)
            return Result.Failure<int>(firstNameResult.Error);

        var lastNameResult = LastName.Create(dto.LastName);
        if (lastNameResult.IsFailure)
            return Result.Failure<int>(lastNameResult.Error);

        var dateOfBirthResult = DateOfBirth.Create(dto.DateOfBirth);
        if (dateOfBirthResult.IsFailure)
            return Result.Failure<int>(dateOfBirthResult.Error);

        var phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);
        if (phoneNumberResult.IsFailure)
            return Result.Failure<int>(phoneNumberResult.Error);

        var patient = Patient.Create(
            firstNameResult.Value,
            lastNameResult.Value,
            dateOfBirthResult.Value,
            dto.Gender,
            phoneNumberResult.Value,
            dto.Address);

        if (patient.IsFailure)
            return Result.Failure<int>(patient.Error);

        await repo.AddAsync(patient.Value);
        await unitOfWork.SaveChangesAsync();

        return Result.Success(patient.Value.Id);
    }

    public async Task<Result> UpdatePatient(
        int id,
        UpdatePatientDto dto)
    {
        if (id <= 0)
            return Result.Failure(ServiceErrors.InvalidId);

        var patient = await repo.GetByIdAsync(id);
        if (patient is null)
            return Result.Failure(ServiceErrors.NotFound);

        var firstNameResult = FirstName.Create(dto.FirstName);
        if (firstNameResult.IsFailure)
            return Result.Failure(firstNameResult.Error);

        var lastNameResult = LastName.Create(dto.LastName);
        if (lastNameResult.IsFailure)
            return Result.Failure(lastNameResult.Error);

        var dateOfBirthResult = DateOfBirth.Create(dto.DateOfBirth);
        if (dateOfBirthResult.IsFailure)
            return Result.Failure(dateOfBirthResult.Error);

        var phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);
        if (phoneNumberResult.IsFailure)
            return Result.Failure(phoneNumberResult.Error);

        var updateResult = patient.Update(
            firstNameResult.Value,
            lastNameResult.Value,
            dateOfBirthResult.Value,
            dto.Gender,
            phoneNumberResult.Value,
            dto.Address);

        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}