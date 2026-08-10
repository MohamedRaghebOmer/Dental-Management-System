using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class VisitTreatment : Entity
{
    public static class Constants
    {
        public const int NotesMaxLength = 500;
    }

    public ToothNumber? ToothNumber { get; private set; } = default!;
    public Id VisitId { get; private set; } = default!;
    public Id TreatmentId { get; private set; } = default!;
    public int Count { get; private set; } = 1; // Default value is 1, updatable
    public Money TreatmentPrice { get; private set; } = default!;
    public decimal TotalPrice => TreatmentPrice.Value * Count; // Computed property
    public string? Notes { get; private set; }

    public Visit Visit { get; private set; } = default!;
    public Treatment Treatment { get; private set; } = default!;

    private VisitTreatment() { } // EF Core

    private VisitTreatment(
        Id visitId,
        Id treatmentId,
        ToothNumber? toothNumber,
        int count,
        Money treatmentPrice,
        string? notes)
    {
        VisitId = visitId;
        TreatmentId = treatmentId;
        ToothNumber = toothNumber;
        Count = count;
        TreatmentPrice = treatmentPrice;
        Notes = notes;
    }

    internal static Result<VisitTreatment> Create(
        ToothNumber? toothNumber,
        Id visitId,
        Id treatmentId,
        int count,
        Money treatmentPrice,
        string? notes)
    {
        notes = notes?.Trim();

        var validationResult = Validate(count, notes);
        if (validationResult.IsFailure)
        {
            return Result.Failure<VisitTreatment>(validationResult.Error);
        }

        return new VisitTreatment(
            visitId: visitId,
            treatmentId: treatmentId,
            toothNumber: toothNumber,
            count: count,
            treatmentPrice: treatmentPrice,
            notes: notes);
    }

    internal Result Update(
        Id treatmentId,
        ToothNumber? toothNumber,
        int count,
        string? notes)
    {
        notes = notes?.Trim();

        var validationResult = Validate(count, notes);
        if (validationResult.IsFailure)
        {
            return Result.Failure(validationResult.Error);
        }

        TreatmentId = treatmentId;
        ToothNumber = toothNumber;
        Count = count;
        Notes = notes;

        return Result.Success();
    }

    private static Result Validate(
        int count,
        string? notes)
    {
        if (count <= 0)
        {
            return Result.Failure(DomainErrors.Entities.VisitTreatment.Count.EqualToOrLessThanZero);
        }

        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.VisitTreatment.Notes.TooLong);
        }

        return Result.Success();
    }
}
