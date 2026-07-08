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

    public Id? AppointmentId { get; private set; }
    public Money PaidAmount { get; private set; }
    public Money DiscountAmount { get; private set; }
    public Money TotalAmount { get; private set; }
    public DateTime Date { get; private set; }
    public string? Notes { get; private set; }

    public Appointment? Appointment { get; private set; }

    private Visit() { } // EF Core

    private Visit(
        Id? appointmentId,
        Money paidAmount,
        Money discountAmount,
        Money totalAmount,
        DateTime date,
        string? notes)
    {
        AppointmentId = appointmentId;
        PaidAmount = paidAmount;
        DiscountAmount = discountAmount;
        TotalAmount = totalAmount;
        Date = date;
        Notes = notes;
    }

    public static Result<Visit> Create(
        Id? appointmentId,
        Money paidAmount,
        Money discountAmount,
        Money totalAmount,
        DateTime date,
        string? notes)
    {
        var validateResult = Validate(
            paidAmount,
            discountAmount,
            totalAmount,
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
            TotalAmount = totalAmount,
            Date = date,
            Notes = notes?.Trim()
        };
    }

    public Result Update(
        Id? appointmentId,
        Money paidAmount,
        Money discountAmount,
        Money totalAmount,
        DateTime date,
        string? notes)
    {
        var validateResult = Validate(
            paidAmount,
            discountAmount,
            totalAmount,
            date,
            notes);

        if (validateResult.IsFailure)
        {
            return Result.Failure(validateResult.Error);
        }

        AppointmentId = appointmentId;
        PaidAmount = paidAmount;
        DiscountAmount = discountAmount;
        TotalAmount = totalAmount;
        Date = date;
        Notes = notes?.Trim();

        return Result.Success();
    }


    private static Result Validate(
        Money paidAmount,
        Money discountAmount,
        Money totalAmount,
        DateTime date,
        string? notes)
    {
        if (paidAmount.Value > totalAmount.Value)
        {
            return Result.Failure(DomainErrors.Visit.PaidAmount.AmountMustLessThanTotalAmount);
        }
        if (discountAmount.Value > totalAmount.Value)
        {
            return Result.Failure(DomainErrors.Visit.DiscountAmount.AmountCannotBeGreaterThanTotalAmount);
        }
        if (date > DateTime.UtcNow)
        {
            return Result.Failure(DomainErrors.Visit.Date.CannotBeInTheFuture);
        }

        notes = notes?.Trim();
        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Visit.Notes.TooLong);
        }

        return Result.Success();
    }
}