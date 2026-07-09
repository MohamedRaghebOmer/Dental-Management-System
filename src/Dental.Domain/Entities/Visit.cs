using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Visit : Entity
{
    public static class Constants
    {
        public const int NotesMaxLength = 500;
    }

    public Id? AppointmentId { get; private set; } = default!;
    public Money PaidAmount { get; private set; } = default!;
    public Money DiscountAmount { get; private set; } = default!;
    public DateTime Date { get; private set; }
    public string? Notes { get; private set; }

    public Appointment? Appointment { get; private set; }
    public ICollection<VisitToothTreatment> VisitToothTreatments { get; private set; } = [];
    public ICollection<Prescription> Prescriptions { get; private set; } = [];

    private Visit() { } // EF Core

    private Visit(
        Id? appointmentId,
        Money paidAmount,
        Money discountAmount,
        DateTime date,
        string? notes)
    {
        AppointmentId = appointmentId;
        PaidAmount = paidAmount;
        DiscountAmount = discountAmount;
        Date = date;
        Notes = notes;
    }

    public static Result<Visit> Create(
        Id? appointmentId,
        Money paidAmount,
        Money discountAmount,
        DateTime date,
        string? notes)
    {
        var validateResult = Validate(
            paidAmount,
            discountAmount,
            date,
            notes);

        if (validateResult.IsFailure)
        {
            return Result.Failure<Visit>(validateResult.Error);
        }

        return new Visit
        {
            AppointmentId = appointmentId,
            PaidAmount = paidAmount,
            DiscountAmount = discountAmount,
            Date = date,
            Notes = notes?.Trim()
        };
    }

    public Result Update(
        Id? appointmentId,
        Money paidAmount,
        Money discountAmount,
        DateTime date,
        string? notes)
    {
        var validateResult = Validate(
            paidAmount,
            discountAmount,
            date,
            notes);

        if (validateResult.IsFailure)
        {
            return Result.Failure(validateResult.Error);
        }

        AppointmentId = appointmentId;
        PaidAmount = paidAmount;
        DiscountAmount = discountAmount;
        Date = date;
        Notes = notes?.Trim();

        return Result.Success();
    }


    private static Result Validate(
        Money paidAmount,
        Money discountAmount,
        DateTime date,
        string? notes)
    {
        if (date > DateTime.Now)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Date.CannotBeInTheFuture);
        }

        notes = notes?.Trim();
        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Notes.TooLong);
        }

        return Result.Success();
    }
}