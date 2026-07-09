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
        Id patientId,
        Id visitId,
        string? notes)
    {
        this.PatientId = patientId;
        this.VisitId = visitId;
        this.Notes = notes;
    }

    
    // ========================= Constants ========================
    public static class Constants
    {
        public const int NotesMaxLength = 500;
    }

    
    // ========================= Proprieties ========================
    public Id PatientId { get; private set; } = default!;
    public Id VisitId { get; private set; } = default!;
    public string? Notes { get; private set; }


    // ========================= Navigation Properties ========================
    public Patient Patient { get; private set; } = default!;
    public Visit Visit { get; private set; } = default!;


    // ========================= Methods ========================
    public static Result<Prescription> Create(
        Id patientId, 
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
            PatientId = patientId,
            VisitId = visitId,
            Notes = notes
        });
    }

    public Result Update(
        Id patientId,
        Id visitId,
        string? notes)
    {
        var validateResult = Validate(notes);
        if (!validateResult.IsSuccess)
        {
            return Result.Failure(validateResult.Error);
        }

        this.PatientId = patientId;
        this.VisitId = visitId;
        this.Notes = notes;

        return Result.Success();
    }

    private static Result Validate(
        string? notes)
    {
        if (notes?.Trim().Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Precription.Notes.TooLong);
        }

        return Result.Success();
    }
}