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
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime ScheduledVisitDateTime { get; private set; }
    public DateTime? ActualVisitDateTime { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public string? Notes { get; private set; }

    public Patient Patient { get; private set; } = default!;
    public Visit? Visit { get; private set; } = default!;

    private Appointment() { } // EF Core

    private Appointment(
        Id patientId,
        DateTime createdAt,
        DateTime scheduledVisitDateTime,
        DateTime? actualVisitDateTime,
        AppointmentStatus status,
        string? notes)
    {
        PatientId = patientId;
        CreatedAt = createdAt;
        ScheduledVisitDateTime = scheduledVisitDateTime;
        ActualVisitDateTime = actualVisitDateTime;
        Status = status;
        Notes = notes;
    }

    public static Result<Appointment> Create(
        Id patientId,
        DateTime scheduledVisitDateTime,
        string? notes)
    {
        if (scheduledVisitDateTime < DateTime.Now)
        {
            return Result.Failure<Appointment>(DomainErrors.Entities.Appointment.ScheduledVisitDateTime.InThePast);
        }

        notes = notes?.Trim();

        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure<Appointment>(DomainErrors.Entities.Appointment.Notes.TooLong);
        }

        return new Appointment(
            patientId,
            DateTime.Now,
            scheduledVisitDateTime,
            null,
            AppointmentStatus.Pending,
            notes);
    }

    public Result Update(
        Id patientId,
        DateTime scheduledVisitDateTime,
        string? notes)
    {
        if (scheduledVisitDateTime < DateTime.Now)
        {
            return Result.Failure(DomainErrors.Entities.Appointment.ScheduledVisitDateTime.InThePast);
        }

        if (Status != AppointmentStatus.Pending)
        {
            if (scheduledVisitDateTime != this.ScheduledVisitDateTime)
            {
                return Result.Failure(DomainErrors.Entities.Appointment.ScheduledVisitDateTime.CannotBeChangedWhenStatusIsNotPending);
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
        this.ScheduledVisitDateTime = scheduledVisitDateTime;
        this.Notes = notes;

        return Result.Success();
    }


    public Result ChangeStatusToPending()
    {
        if (Status == AppointmentStatus.Pending)
            return Result.Failure(DomainErrors.Entities.Appointment
                .Status.CannotBePendingWhenAlreadyPending);

        if (Status == AppointmentStatus.Canceled)
            return Result.Failure(DomainErrors.Entities.Appointment.
                Status.CannotBePendingWhenCanceled);

        ActualVisitDateTime = null;
        Status = AppointmentStatus.Pending;

        return Result.Success();
    }

    public Result Cancel()
    {
        if (Status == AppointmentStatus.Canceled)
        {
            return Result.Failure(
                DomainErrors.Entities
                .Appointment
                .Status
                .CannotBeCanceledWhenAlreadyCanceled);
        }

        if (Status == AppointmentStatus.Completed)
        {
            return Result.Failure(
                DomainErrors.Entities
                .Appointment
                .Status
                .CannotBeCanceledWhenCompleted);
        }

        Status = AppointmentStatus.Canceled;
        return Result.Success();
    }

    public Result Complete()
    {
        if (Status == AppointmentStatus.Completed)
        {
            return Result.Failure(DomainErrors.Entities
                    .Appointment
                    .Status
                    .CannotBeCompletedWhenAlreadyCompleted);
        }

        if (Status == AppointmentStatus.Canceled)
        {
            return Result.Failure(DomainErrors.Entities
                    .Appointment
                    .Status
                    .CannotBeCompletedWhenCanceled);
        }

        Status = AppointmentStatus.Completed;
        ActualVisitDateTime = DateTime.Now;

        return Result.Success();
    }

    public bool IsMissed() =>
        Status == AppointmentStatus.Pending &&
        ScheduledVisitDateTime < DateTime.Now &&
        ActualVisitDateTime == null;
}