using Dental.Domain.Enums;
using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Appointment : Entity
{
    public static class Constants
    {
        public const int NotesMaxLength = 500;
    }

    public Id PatientId { get; private set; }
    public DateTime AppointmentDate { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public string? Notes { get; private set; }

    public Patient Patient { get; private set; }
    public Visit? Visit { get; private set; }

    private Appointment() { } // EF Core

    private Appointment(
        Id patientId,
        DateTime appointmentDate,
        DateTime? completedAt,
        AppointmentStatus status,
        string? notes)
    {
        PatientId = patientId;
        AppointmentDate = appointmentDate;
        CompletedAt = completedAt;
        Status = status;
        Notes = notes;
    }

    public static Result<Appointment> Create(
        Id patientId,
        DateTime appointmentDate,
        string? notes)
    {
        if (appointmentDate < DateTime.UtcNow)
        {
            return Result.Failure<Appointment>(DomainErrors.Appointment.Date.InThePast);
        }

        notes = notes?.Trim();

        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure<Appointment>(DomainErrors.Appointment.Notes.TooLong);
        }

        return new Appointment(
            patientId,
            appointmentDate,
            null,
            AppointmentStatus.Pending,
            notes);
    }

    public Result Update(
        Id patientId,
        DateTime appointmentDate,
        string? notes)
    {
        if (appointmentDate < DateTime.UtcNow)
        {
            return Result.Failure(DomainErrors.Appointment.Date.InThePast);
        }

        if (Status != AppointmentStatus.Pending)
        {
            if (appointmentDate != this.AppointmentDate)
            {
                return Result.Failure(DomainErrors.Appointment.Date.CannotBeChangedWhenStatusIsNotPending);
            }

            if (patientId != this.PatientId)
            {
                return Result.Failure(DomainErrors.Appointment.PatientId.CannotBeChangedWhenStatusIsNotPending);
            }
        }

        notes = notes?.Trim();

        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Appointment.Notes.TooLong);
        }

        this.PatientId = patientId;
        this.AppointmentDate = appointmentDate;
        this.Notes = notes;

        return Result.Success();
    }

    public Result Cancel()
    {
        if (Status == AppointmentStatus.Canceled
            || Status == AppointmentStatus.Completed)
        {
            return Result.Failure(
                DomainErrors
                .Appointment
                .Status
                .CannotBeCanceledWhenCompletedOrCanceled);
        }

        Status = AppointmentStatus.Canceled;
        return Result.Success();
    }

    public Result Complete()
    {
        if (Status == AppointmentStatus.Completed
            || Status == AppointmentStatus.Canceled)
        {
            return Result.Failure(DomainErrors
                    .Appointment
                    .Status
                    .CannotBeCompletedWhenCanceledOrCompleted);
        }

        Status = AppointmentStatus.Completed;
        CompletedAt = DateTime.UtcNow;

        return Result.Success();
    }

    public bool IsMissed() =>
        Status == AppointmentStatus.Pending &&
        AppointmentDate < DateTime.UtcNow;
}