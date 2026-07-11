using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Prescription : Entity
{
    // ========================= Constructors ========================
    private Prescription() { }  // EF Core

    private Prescription(
        Id visitId,
        string? notes)
    {
        this.VisitId = visitId;
        this.Notes = notes;
    }


    // ========================= Constants ========================
    public static class Constants
    {
        public const int NotesMaxLength = 500;
    }


    // ========================= Proprieties ========================
    public Id VisitId { get; private set; } = default!;
    public string? Notes { get; private set; }


    // ========================= Navigation Properties ========================
    public Visit Visit { get; private set; } = default!;
    public ICollection<PrescriptionItem> PrescriptionItems { get; private set; } = [];



    // ========================= Methods ========================
    public static Result<Prescription> Create(
        Id visitId,
        string? notes)
    {
        var validateResult = Validate(notes);
        if (!validateResult.IsSuccess)
        {
            return Result.Failure<Prescription>(validateResult.Error);
        }

        return Result.Success(new Prescription
        {
            VisitId = visitId,
            Notes = notes
        });
    }

    public Result Update(
        Id visitId,
        string? notes)
    {
        var validateResult = Validate(notes);
        if (!validateResult.IsSuccess)
        {
            return Result.Failure(validateResult.Error);
        }

        this.VisitId = visitId;
        this.Notes = notes;

        return Result.Success();
    }

    private static Result Validate(
        string? notes)
    {
        if (notes?.Trim().Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Prescription.Notes.TooLong);
        }

        return Result.Success();
    }
}