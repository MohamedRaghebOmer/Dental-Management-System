using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Appointment;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
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
        AppointmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(
            "AppointmentService.CreateAsync is called. {CreateAppointmentDto}", dto);

        var entityResult = await BuildEntityAndValidateForeignKeys(
            dto,
            cancellationToken);

        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        await repo.AddAsync(entityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Appointment created successfully. {Id}", entityResult.Value.Id);

        return Result.Success(entityResult.Value.Id);
    }

    public async Task<Result> UpdateAsync(
        int appointmentId,
        AppointmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(
            "AppointmentService.UpdateAsync is called. {AppointmentId} {UpdateAppointmentDto}", appointmentId, dto);

        var validEntity = await BuildEntityAndValidateForeignKeys(
            dto, 
            cancellationToken, 
            appointmentId);

        if (validEntity.IsFailure)
        {
            return Result.Failure(validEntity.Error);
        }

        var appointment = await repo.GetByIdAsync(appointmentId, cancellationToken);
        if (appointment == null)
        {
            logger.LogWarning("Failed to update appointment: Appointment not found.", cancellationToken);
            return Result.Failure(ServiceErrors.NotFound);
        }

        // Update the appointment properties
        var updateResult = appointment.Update(
            validEntity.Value.PatientId,
            dto.AppointmentDate,
            dto.Notes);

        if (updateResult.IsFailure)
        {
            logger.LogWarning("Failed to update appointment: Invalid appointment data. {error}", updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Appointment updated successfully.", cancellationToken);

        return Result.Success(cancellationToken);
    }

    private async Task<Result<Appointment>> BuildEntityAndValidateForeignKeys(
        AppointmentRequestDto requestDto,
        CancellationToken cancellationToken = default,
        int? id = null)
    {
        if (id is <= 0)
        {
            logger.LogWarning("Failed to update appointment: Invalid appointment ID. {Id}", id);
            return Result.Failure<Appointment>(ServiceErrors.InvalidId);
        }

        var patientIdResult = Id.Create(requestDto.PatientId);
        if (patientIdResult.IsFailure)
        {
            logger.LogWarning("Failed to create appointment: Invalid patient ID. {error}", patientIdResult.Error);
            return Result.Failure<Appointment>(patientIdResult.Error);
        }

        if (!await patientRepo.ExistsAsync(requestDto.PatientId, cancellationToken))
        {
            logger.LogWarning("Failed to create appointment: Patient not found. {PatientId}", requestDto.PatientId);
            return Result.Failure<Appointment>(ServiceErrors.AppointmentErrors.PatientNotFound);
        }

        var appointmentResult = Appointment.Create(
            patientIdResult.Value,
            requestDto.AppointmentDate,
            requestDto.Notes);

        if (appointmentResult.IsFailure)
        {
            logger.LogWarning("Failed to create appointment: Invalid appointment data. {error}", appointmentResult.Error);
            return Result.Failure<Appointment>(appointmentResult.Error);
        }

        return appointmentResult.Value;
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


        await unitOfWork.SaveChangesAsync(cancellationToken);
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

        await unitOfWork.SaveChangesAsync(cancellationToken);
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