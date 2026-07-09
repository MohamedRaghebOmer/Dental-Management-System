using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Appointment;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public class AppointmentService(
    IRepository<Appointment> repo,
    IRepository<Patient> patientRepo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<Appointment, AppointmentResponseDto>> logger)
    : ServiceBase<Appointment, AppointmentResponseDto>(repo, unitOfWork, logger)
    , IAppointmentService
{
    public async Task<Result<int>> CreateAsync(
        CreateAppointmentDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(
            "AppointmentService.CreateAsync is called. {CreateAppointmentDto}", dto);

        var patientIdResult = Id.Create(dto.PatientId);
        if (patientIdResult.IsFailure)
        {
            logger.LogWarning("Failed to create appointment: Invalid patient ID. {error}", patientIdResult.Error);
            return Result.Failure<int>(patientIdResult.Error);
        }

        if (! await patientRepo.ExistsAsync(dto.PatientId, cancellationToken))
        {
            logger.LogWarning("Failed to create appointment: Patient not found. {PatientId}", dto.PatientId);
            return Result.Failure<int>(ServiceErrors.AppointmentErrors.PatientNotFound);
        }

        var appointmentResult = Appointment.Create(
            patientIdResult.Value,
            dto.AppointmentDate,
            dto.Notes);

        if (appointmentResult.IsFailure)
        {
            logger.LogWarning("Failed to create appointment: Invalid appointment data. {error}", appointmentResult.Error);
            return Result.Failure<int>(appointmentResult.Error);
        }

        await repo.AddAsync(appointmentResult.Value, cancellationToken);

        logger.LogInformation("Appointment created successfully.", cancellationToken);

        return Result.Success(appointmentResult.Value.Id);
    }

    public async Task<Result> UpdateAsync(
        int appointmentId,
        UpdateAppointmentDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(
            "AppointmentService.UpdateAsync is called. {AppointmentId} {UpdateAppointmentDto}", appointmentId, dto);

        if (appointmentId <= 0)
        {
            logger.LogWarning("Failed to update appointment: Invalid appointment ID.", cancellationToken);
            return Result.Failure(ServiceErrors.InvalidId);
        }


        var appointment = await repo.GetByIdAsync(appointmentId, cancellationToken);
        if (appointment == null)
        {
            logger.LogWarning("Failed to update appointment: Appointment not found.", cancellationToken);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var patientIdResult = Id.Create(dto.PatientId);
        if (patientIdResult.IsFailure)
        {
            logger.LogWarning("Failed to update appointment: Invalid patient ID. {error}", patientIdResult.Error);
            return Result.Failure(patientIdResult.Error);
        }

        // Update the appointment properties
        var updateResult = appointment.Update(
            patientIdResult.Value,
            dto.AppointmentDate,
            dto.Notes);

        if (updateResult.IsFailure)
        {
            logger.LogWarning("Failed to update appointment: Invalid appointment data. {error}", updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogInformation("Appointment updated successfully.", cancellationToken);

        return Result.Success(cancellationToken);
    }

    public async Task<Result> CancelAsync(int id,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("AppointmentService.CancelAsync is called. {AppointmentId}", id);

        if (id <= 0)
        {
            logger.LogWarning("Failed to cancel appointment: Invalid appointment ID.", cancellationToken);
            return Result.Failure(ServiceErrors.InvalidId);
        }


        var appointment = await repo.GetByIdAsync(id, cancellationToken);
        if (appointment == null)
        {
            logger.LogWarning("Failed to cancel appointment: Appointment not found.", cancellationToken);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var cancelResult = appointment.Cancel();
        if (cancelResult.IsFailure)
        {
            logger.LogWarning("Failed to cancel appointment: {error}", cancelResult.Error);
            return Result.Failure(cancelResult.Error);
        }


        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogInformation("Appointment canceled successfully.", cancellationToken);

        return Result.Success(cancellationToken);
    }

    public async Task<Result> CompleteAsync(int id,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("AppointmentService.CompleteAsync is called. {AppointmentId}", id);

        if (id <= 0)
        {
            logger.LogWarning("Failed to complete appointment: Invalid appointment ID.", cancellationToken);
            return Result.Failure(ServiceErrors.InvalidId);
        }


        var appointment = await repo.GetByIdAsync(id, cancellationToken);
        if (appointment == null)
        {
            logger.LogWarning("Failed to complete appointment: Appointment not found.", cancellationToken);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var completeResult = appointment.Complete();
        if (completeResult.IsFailure)
        {
            logger.LogWarning("Failed to complete appointment: {error}", completeResult.Error);
            return Result.Failure(completeResult.Error);
        }

        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogInformation("Appointment completed successfully.", cancellationToken);

        return Result.Success(cancellationToken);
    }

    public async Task<Result<bool>> IsMissed(int id,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("AppointmentService.IsMissed is called. {AppointmentId}", id);

        if (id <= 0)
        {
            logger.LogWarning("Failed to check if appointment is missed: Invalid appointment ID.", cancellationToken);
            return Result.Failure<bool>(ServiceErrors.InvalidId);
        }

        var appointment = await repo.GetByIdAsync(id, cancellationToken);
        if (appointment == null)
        {
            logger.LogWarning("Failed to check if appointment is missed: Appointment not found.", cancellationToken);
            return Result.Failure<bool>(ServiceErrors.NotFound);
        }

        logger.LogInformation("Appointment with ID {id} is {missed}.",
            id, appointment.IsMissed());

        return Result.Success(appointment.IsMissed());
    }
}