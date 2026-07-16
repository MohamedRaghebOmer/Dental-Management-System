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

    public ToothNumber ToothNumber { get; private set; } = default!;
    public Id VisitId { get; private set; } = default!;
    public Id TreatmentId { get; private set; } = default!;
    public Money Price { get; private set; } = default!;
    public string? Notes { get; private set; }

    public Visit Visit { get; private set; } = default!;
    public Treatment Treatment { get; private set; } = default!;

    private VisitTreatment() { } // EF Core

    private VisitTreatment(
        ToothNumber toothNumber,
        Id visitId,
        Id treatmentId,
        Money price,
        string? notes)
    {
        ToothNumber = toothNumber;
        VisitId = visitId;
        TreatmentId = treatmentId;
        Price = price;
        Notes = notes;
    }

    internal static Result<VisitTreatment> Create(
        ToothNumber toothNumber,
        Id visitId,
        Id treatmentId,
        Money price, // Auto set from table Treatments<treatmentId>.Price | NOT updatable
        string? notes)
    {
        notes = notes?.Trim();

        var validationResult = Validate(notes);
        if (validationResult.IsFailure)
        {
            return Result.Failure<VisitTreatment>(validationResult.Error);
        }

        return new VisitTreatment(
            toothNumber,
            visitId,
            treatmentId,
            price,
            notes);
    }

    internal Result Update(
        ToothNumber toothNumber,
        Id treatmentId,
        string? notes)
    {
        notes = notes?.Trim();

        var validationResult = Validate(notes);
        if (validationResult.IsFailure)
        {
            return Result.Failure(validationResult.Error);
        }

        ToothNumber = toothNumber;
        TreatmentId = treatmentId;
        Notes = notes;

        return Result.Success();
    }

    private static Result Validate(
        string? notes)
    {
        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.VisitTreatment.Notes.TooLong);
        }

        return Result.Success();
    }
}
