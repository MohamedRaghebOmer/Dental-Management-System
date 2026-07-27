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

        if (await _repo.ExistsByNameAsync(
            entityResult.Value.Name, cancellationToken: cancellationToken))
        {
            _logger.LogWarning("Patient with the same name already exists. {Name}", entityResult.Value.Name);
            return Result.Failure<int>(ServiceErrors.Patient.DuplicateName);
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
            return Result.Failure(ServiceErrors.Common.NotFound);
        }

        if (await _repo.ExistsByNameAsync(
            buildEntityResult.Value.Name,
            excludedId: createIdResult.Value,
            cancellationToken: cancellationToken))
        {
            _logger.LogWarning("Patient with the same name already exists. {Name}", buildEntityResult.Value.Name);
            return Result.Failure(ServiceErrors.Patient.DuplicateName);
        }

        var updateResult = patient.Update(
            buildEntityResult.Value.Name,
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

    public async Task<PatientResponseDto?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        var patient = await _repo.GetByNameAsync(name, cancellationToken);

        if (patient is null)
        {
            _logger.LogWarning("Patient not found by name. {Name}", name);
            return null;
        }

        return PatientResponseDto.ToResponseDto(patient);
    }

    async Task<Result<bool>> IPatientService.CanDeleteAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var idResult = Id.Create(id);
        if (idResult.IsFailure)
        {
            _logger.LogWarning("Invalid Id. {Id} {Error}", id, idResult.Error);
            return Result.Failure<bool>(idResult.Error);
        }

        return await _repo.CanDeleteAsync(idResult.Value, cancellationToken);
    }

    private Result<Patient> BuildEntity(PatientRequestDto dto)
    {
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
            dto.Name,
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