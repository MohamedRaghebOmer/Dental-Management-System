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

    public Id PatientId { get; private set; } = default!;
    public DateTime Date { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public string? Notes { get; private set; }

    public Patient Patient { get; private set; } = default!;
    public Visit? Visit { get; private set; } = default!;

    private Appointment() { } // EF Core

    private Appointment(
        Id patientId,
        DateTime date,
        DateTime? completedAt,
        AppointmentStatus status,
        string? notes)
    {
        PatientId = patientId;
        Date = date;
        CompletedAt = completedAt;
        Status = status;
        Notes = notes;
    }

    public static Result<Appointment> Create(
        Id patientId,
        DateTime appointmentDate,
        string? notes)
    {
        if (appointmentDate < DateTime.Now)
        {
            return Result.Failure<Appointment>(DomainErrors.Entities.Appointment.Date.InThePast);
        }

        notes = notes?.Trim();

        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure<Appointment>(DomainErrors.Entities.Appointment.Notes.TooLong);
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
        if (appointmentDate < DateTime.Now)
        {
            return Result.Failure(DomainErrors.Entities.Appointment.Date.InThePast);
        }

        if (Status != AppointmentStatus.Pending)
        {
            if (appointmentDate != this.Date)
            {
                return Result.Failure(DomainErrors.Entities.Appointment.Date.CannotBeChangedWhenStatusIsNotPending);
            }

            if (patientId != this.PatientId)
            {
                return Result.Failure(DomainErrors.Entities.Appointment.PatientId.CannotBeChangedWhenStatusIsNotPending);
            }
        }

        notes = notes?.Trim();

        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Appointment.Notes.TooLong);
        }

        this.PatientId = patientId;
        this.Date = appointmentDate;
        this.Notes = notes;

        return Result.Success();
    }

    public Result Cancel()
    {
        if (Status == AppointmentStatus.Canceled
            || Status == AppointmentStatus.Completed)
        {
            return Result.Failure(
                DomainErrors.Entities
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
            return Result.Failure(DomainErrors.Entities
                    .Appointment
                    .Status
                    .CannotBeCompletedWhenCanceledOrCompleted);
        }

        Status = AppointmentStatus.Completed;
        CompletedAt = DateTime.Now;

        return Result.Success();
    }

    public bool IsMissed() =>
        Status == AppointmentStatus.Pending &&
        Date < DateTime.Now;
}