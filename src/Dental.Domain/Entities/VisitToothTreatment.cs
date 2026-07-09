using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class VisitToothTreatment : Entity
{
    public static class Constants
    {
        public const int NotesMaxLength = 500;
    }

    public ToothNumber ToothNumber { get; private set; } = default!;
    public Id VisitId { get; private set; } = default!;
    public Id ServiceId { get; private set; } = default!;
    public Money Price { get; private set; } = default!;
    public string? Notes { get; private set; }

    public Visit Visit { get; private set; } = default!;
    public Treatment Treatment { get; private set; } = default!;

    private VisitToothTreatment() { } // EF Core

    private VisitToothTreatment(
        ToothNumber toothNumber,
        Id visitId,
        Id serviceId,
        Money price,
        string? notes)
    {
        ToothNumber = toothNumber;
        VisitId = visitId;
        ServiceId = serviceId;
        Price = price;
        Notes = notes;
    }

    public static Result<VisitToothTreatment> Create(
        ToothNumber toothNumber,
        Id visitId,
        Id serviceId,
        Money price,
        string? notes)
    {
        var validationResult = Validate(notes);

        if (validationResult.IsFailure)
        {
            return Result.Failure<VisitToothTreatment>(validationResult.Error);
        }

        return new VisitToothTreatment(
            toothNumber,
            visitId,
            serviceId,
            price,
            notes?.Trim());
    }

    public Result Update(
        ToothNumber toothNumber,
        Id visitId,
        Id serviceId,
        Money price,
        string? notes)
    {
        var validationResult = Validate(notes);

        if (validationResult.IsFailure)
        {
            return Result.Failure(validationResult.Error);
        }

        ToothNumber = toothNumber;
        VisitId = visitId;
        ServiceId = serviceId;
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
            return Result.Failure(DomainErrors.Entities.VisitToothTreatment.Notes.TooLong);
        }

        return Result.Success();
    }
}
