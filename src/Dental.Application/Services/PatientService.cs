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

public class PatientService
    : ServiceBase<Patient, PatientResponseDto>
    , IPatientService
{
    private readonly IPatientRepository _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PatientService> _logger;

    public PatientService(
        IPatientRepository repo,
        IUnitOfWork unitOfWork,
        ILogger<PatientService> logger) : base(repo, unitOfWork, logger)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<int>> CreateAsync(
        PatientRequestDto dto,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("PatientService.CreateAsync is called. {dto}", dto);

        var entityResult = BuildEntity(dto);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        _repo.Add(entityResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Patient created successfully. {PatientId}", entityResult.Value.Id);

        return Result.Success(entityResult.Value.Id.Value);
    }

    public async Task<Result> UpdateAsync(
        int id,
        PatientRequestDto dto,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "PatientService.UpdateAsync is called. {PatientId} {UpdatePatientDto}",
            id, dto);

        var createIdResult = Id.Create(id);
        if (createIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid Id. {Id} {Error}", id, createIdResult.Error);
            return Result.Failure(createIdResult.Error);
        }

        var buildEntityResult = BuildEntity(dto);
        if (buildEntityResult.IsFailure)
        {
            return Result.Failure(buildEntityResult.Error);
        }

        var patient = await _repo.GetByIdAsync(createIdResult.Value, cancellationToken);
        if (patient is null)
        {
            _logger.LogWarning("Patient not found. {Id}", id);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var updateResult = patient.Update(
            buildEntityResult.Value.FirstName,
            buildEntityResult.Value.LastName,
            buildEntityResult.Value.Age,
            dto.Gender,
            buildEntityResult.Value.PhoneNumber);

        if (updateResult.IsFailure)
        {
            _logger.LogWarning("Failed to update patient due to invalid patient data. {Error}", updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Patient updated successfully. {PatientId}", patient.Id);

        return Result.Success();
    }

    private Result<Patient> BuildEntity(PatientRequestDto dto)
    {
        var firstNameResult = FirstName.Create(dto.FirstName);
        if (firstNameResult.IsFailure)
        {
            _logger.LogWarning("Failed to create patient due to invalid first name. {FirstName}", dto.FirstName);
            return Result.Failure<Patient>(firstNameResult.Error);
        }

        var lastNameResult = LastName.Create(dto.LastName);
        if (lastNameResult.IsFailure)
        {
            _logger.LogWarning("Failed to create patient due to invalid last name. {LastName}", dto.LastName);
            return Result.Failure<Patient>(lastNameResult.Error);
        }

        PhoneNumber? phoneNumber = null;
        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
        {
            var phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);
            if (phoneNumberResult.IsFailure)
            {
                _logger.LogWarning("Failed to create patient due to invalid phone number. {PhoneNumber}", dto.PhoneNumber);
                return Result.Failure<Patient>(phoneNumberResult.Error);
            }


            phoneNumber = phoneNumberResult.Value;
        }

        var patientResult = Patient.Create(
            firstNameResult.Value,
            lastNameResult.Value,
            dto.Age,
            dto.Gender,
            phoneNumber);

        if (patientResult.IsFailure)
        {
            _logger.LogWarning("Failed to create patient due to invalid patient data. {Error}", patientResult.Error);
            return Result.Failure<Patient>(patientResult.Error);
        }

        return Result.Success(patientResult.Value);
    }
}