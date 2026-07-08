using Dental.Application.Abstractions;
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
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<Appointment, AppointmentResponseDto>> logger)
    : ServiceBase<Appointment, AppointmentResponseDto>(repo, unitOfWork, logger)
{
    public async Task<Result<int>> CreateAsync(CreateAppointmentDto dto)
    {
        var patientIdResult = Id.Create(dto.PatientId);
        if (patientIdResult.IsFailure)
            return Result.Failure<int>(patientIdResult.Error);

        var appointmentResult = Appointment.Create(
            patientIdResult.Value,
            dto.AppointmentDate,
            dto.Notes);

        if (appointmentResult.IsFailure)
            return Result.Failure<int>(appointmentResult.Error);

        await repo.AddAsync(appointmentResult.Value);
        await unitOfWork.CommitAsync();

        return Result.Success(appointmentResult.Value.Id);
    }

    public async Task<Result> UpdateAsync(
        int appointmentId,
        UpdateAppointmentDto dto)
    {
        if (appointmentId <= 0)
            return Result.Failure(ServiceErrors.InvalidId);

        var appointment = await repo.GetByIdAsync(appointmentId);
        if (appointment == null)
            return Result.Failure(ServiceErrors.NotFound);

        var patientIdResult = Id.Create(dto.PatientId);
        if (patientIdResult.IsFailure)
            return Result.Failure(patientIdResult.Error);

        // Update the appointment properties
        var updateResult = appointment.Update(
            patientIdResult.Value,
            dto.AppointmentDate,
            dto.Notes);

        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);

        await unitOfWork.CommitAsync();

        return Result.Success();
    }

    public async Task<Result> CancelAsync(int id)
    {
        if (id <= 0)
            return Result.Failure(ServiceErrors.InvalidId);

        var appointment = await repo.GetByIdAsync(id);
        if (appointment == null)
            return Result.Failure(ServiceErrors.NotFound);

        var cancelResult = appointment.Cancel();
        if (cancelResult.IsFailure)
            return Result.Failure(cancelResult.Error);

        await unitOfWork.CommitAsync();
        return Result.Success();
    }

    public async Task<Result> CompleteAsync(int id)
    {
        if (id <= 0)
            return Result.Failure(ServiceErrors.InvalidId);

        var appointment = await repo.GetByIdAsync(id);
        if (appointment == null)
            return Result.Failure(ServiceErrors.NotFound);

        var completeResult = appointment.Complete();
        if (completeResult.IsFailure)
            return Result.Failure(completeResult.Error);

        await unitOfWork.CommitAsync();
        return Result.Success();
    }

    public async Task<Result<bool>> IsMissed(int id)
    {
        if (id <= 0)
            return Result.Failure<bool>(ServiceErrors.InvalidId);

        var appointment = await repo.GetByIdAsync(id);
        if (appointment == null)
            return Result.Failure<bool>(ServiceErrors.NotFound);

        return Result.Success(appointment.IsMissed());
    }
}