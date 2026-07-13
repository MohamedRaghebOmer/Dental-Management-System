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
        Money price,
        string? notes)
    {
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
            notes?.Trim());
    }

    internal Result Update(
        ToothNumber toothNumber,
        Id treatmentId,
        Money price,
        string? notes)
    {
        var validationResult = Validate(notes);

        if (validationResult.IsFailure)
        {
            return Result.Failure(validationResult.Error);
        }

        ToothNumber = toothNumber;
        TreatmentId = treatmentId;
        Price = price;
        Notes = notes?.Trim();

        return Result.Success();
    }

    private static Result Validate(
        string? notes)
    {
        var trimmedNotes = notes?.Trim();
        if (trimmedNotes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.VisitTreatment.Notes.TooLong);
        }

        return Result.Success();
    }
}
