using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Appointment;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public class AppointmentService
    : ServiceBase<Appointment, AppointmentResponseDto>,
    IAppointmentService
{
    private readonly IAppointmentRepository _repo;
    private readonly IPatientRepository _patientRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AppointmentService> _logger;

    public AppointmentService(
        IAppointmentRepository repo,
        IPatientRepository patientRepo,
        IUnitOfWork unitOfWork,
        ILogger<AppointmentService> logger) : base(repo, unitOfWork, logger)
    {
        _repo = repo;
        _patientRepo = patientRepo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<int>> CreateAsync(
        AppointmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "AppointmentService.CreateAsync is called. {CreateAppointmentDto}", dto);

        var entityResult = await BuildEntityAndValidateForeignKeys(
            dto,
            cancellationToken);

        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        _repo.Add(entityResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Appointment created successfully. {Id}", entityResult.Value.Id);

        return Result.Success(entityResult.Value.Id.Value);
    }

    public async Task<Result> UpdateAsync(
        int appointmentId,
        AppointmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "AppointmentService.UpdateAsync is called. {AppointmentId} {UpdateAppointmentDto}", appointmentId, dto);

        var createIdResult = Id.Create(appointmentId);
        if (createIdResult.IsFailure)
        {
            _logger.LogWarning(
                "Failed to update appointment: Invalid appointment ID. {Id} {Error}",
                appointmentId, createIdResult.Error);
            return Result.Failure<Appointment>(ServiceErrors.InvalidId);
        }

        var validEntity = await BuildEntityAndValidateForeignKeys(
            dto,
            cancellationToken,
            createIdResult.Value);

        if (validEntity.IsFailure)
        {
            return Result.Failure(validEntity.Error);
        }

        var appointment = await _repo.GetByIdAsync(createIdResult.Value, cancellationToken);
        if (appointment == null)
        {
            _logger.LogWarning("Failed to update appointment: Appointment not found. {AppointmentId}", appointmentId);
            return Result.Failure(ServiceErrors.NotFound);
        }

        // Update the appointment properties
        var updateResult = appointment.Update(
            validEntity.Value.PatientId,
            dto.ScheduledVisitDateTime,
            dto.Notes);

        if (updateResult.IsFailure)
        {
            _logger.LogWarning("Failed to update appointment: Invalid appointment data. {error}", updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Appointment updated successfully. {AppointmentId}", appointmentId);

        return Result.Success(cancellationToken);
    }

    private async Task<Result<Appointment>> BuildEntityAndValidateForeignKeys(
        AppointmentRequestDto requestDto,
        CancellationToken cancellationToken = default,
        Id? id = null)
    {
        var patientIdResult = Id.Create(requestDto.PatientId);
        if (patientIdResult.IsFailure)
        {
            _logger.LogWarning(
                "Failed to create appointment: Invalid patient ID. {Id} {Error}", id, patientIdResult.Error);
            return Result.Failure<Appointment>(patientIdResult.Error);
        }

        if (await _repo.ExistsByScheduleVisitDateTimeAsync(
                requestDto.ScheduledVisitDateTime,
                id,
                cancellationToken))
        {
            _logger.LogWarning(
                "Failed to create appointment: There is already an appointment for the given date. {Date}",
                requestDto.ScheduledVisitDateTime);
            return Result.Failure<Appointment>(ServiceErrors.Appointment.DateIsTaken);
        }

        if (!await _patientRepo.ExistsAsync(patientIdResult.Value, cancellationToken))
        {
            _logger.LogWarning("Failed to create appointment: Patient not found. {PatientId}", requestDto.PatientId);
            return Result.Failure<Appointment>(ServiceErrors.Appointment.PatientNotFound);
        }

        var appointmentResult = Appointment.Create(
            patientIdResult.Value,
            requestDto.ScheduledVisitDateTime,
            requestDto.Notes);

        if (appointmentResult.IsFailure)
        {
            _logger.LogWarning("Failed to create appointment: Invalid appointment data. {error}",
                appointmentResult.Error);
            return Result.Failure<Appointment>(appointmentResult.Error);
        }

        return appointmentResult.Value;
    }

    public async Task<Result> CancelAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("AppointmentService.CancelAsync is called. {AppointmentId}", id);

        var createIdResult = Id.Create(id);
        if (createIdResult.IsFailure)
        {
            _logger.LogWarning(
                "Failed to cancel appointment: Invalid appointment ID. {Id} {Error}",
                    id, createIdResult.Error);
            return Result.Failure(createIdResult.Error);
        }

        var appointment = await _repo.GetByIdAsync(createIdResult.Value, cancellationToken);
        if (appointment == null)
        {
            _logger.LogWarning("Failed to cancel appointment: Appointment not found. {AppointmentId}", id);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var cancelResult = appointment.Cancel();
        if (cancelResult.IsFailure)
        {
            _logger.LogWarning("Failed to cancel appointment: {error}", cancelResult.Error);
            return Result.Failure(cancelResult.Error);
        }


        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Appointment canceled successfully. {AppointmentId}", id);

        return Result.Success(cancellationToken);
    }

    public async Task<Result> CompleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("AppointmentService.CompleteAsync is called. {AppointmentId}", id);

        var createIdResult = Id.Create(id);
        if (createIdResult.IsFailure)
        {
            _logger.LogWarning(
                "Invalid appointment ID. {Id} {Error}", id, createIdResult.Error);
            return Result.Failure(createIdResult.Error);
        }

        var appointment = await _repo.GetByIdAsync(createIdResult.Value, cancellationToken);
        if (appointment == null)
        {
            _logger.LogWarning("Failed to complete appointment: Appointment not found. {AppointmentId}", id);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var completeResult = appointment.Complete();
        if (completeResult.IsFailure)
        {
            _logger.LogWarning("Failed to complete appointment: {error}", completeResult.Error);
            return Result.Failure(completeResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Appointment completed successfully. {AppointmentId}", id);

        return Result.Success(cancellationToken);
    }

    public async Task<Result<bool>> IsMissed(
        int id,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("AppointmentService.IsMissed is called. {AppointmentId}", id);

        var createIdResult = Id.Create(id);
        if (createIdResult.IsFailure)
        {
            _logger.LogWarning(
                "Failed to check if appointment is missed: Invalid appointment ID. {Id} {Error}",
                id, createIdResult.Error);
            return Result.Failure<bool>(createIdResult.Error);
        }

        var appointment = await _repo.GetByIdAsync(createIdResult.Value, cancellationToken);
        if (appointment == null)
        {
            _logger.LogWarning("Failed to check if appointment is missed: Appointment not found. {AppointmentId}", id);
            return Result.Failure<bool>(ServiceErrors.NotFound);
        }

        _logger.LogInformation("Appointment with ID {id} is {missed}.",
            id, appointment.IsMissed());

        return Result.Success(appointment.IsMissed());
    }
}