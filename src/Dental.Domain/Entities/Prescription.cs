using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Prescription : Entity
{
    public static class Constants
    {
        public const int NotesMaxLength = 500;
    }


    private Prescription() { }  // EF Core

    private Prescription(string? notes)
    {
        Notes = notes;
    }


    public Id? PatientId { get; private set; } = default!;
    public Id VisitId { get; private set; } = default!;
    public string? Notes { get; private set; }
    public Patient? Patient { get; private set; } = default!;
    public Visit Visit { get; private set; } = default!;


    public IReadOnlyCollection<PrescriptionItem> Items => _items.AsReadOnly();
    private readonly List<PrescriptionItem> _items = [];


    internal static Result<Prescription> Create(
        Id? patientId,
        Id visitId,
        string? notes)
    {
        notes = notes?.Trim();

        var validateResult = Validate(notes);
        if (validateResult.IsFailure)
        {
            return Result.Failure<Prescription>(validateResult.Error);
        }

        return new Prescription(notes);
    }

    internal Result Update(string? notes)
    {
        notes = notes?.Trim();

        var validateResult = Validate(notes);
        if (!validateResult.IsSuccess)
        {
            return Result.Failure(validateResult.Error);
        }

        Notes = notes;

        return Result.Success();
    }

    private static Result Validate(string? notes)
    {
        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Prescription.Notes.TooLong);
        }

        return Result.Success();
    }



    internal Result<PrescriptionItem> AddItem(
        string medicineName,
        decimal dosage,
        MedicineFrequency frequency,
        string? instructions)
    {
        if (_items.Any(i => i.MedicineName == medicineName.Trim()))
        {
            return Result.Failure<PrescriptionItem>(DomainErrors.Entities.Prescription.Item.MedicineWithTheSameNameAlreadyExists);
        }

        var prescriptionItemResult = PrescriptionItem.Create(
            Id,
            medicineName,
            dosage,
            frequency,
            instructions);

        if (prescriptionItemResult.IsFailure)
        {
            return Result.Failure<PrescriptionItem>(prescriptionItemResult.Error);
        }

        _items.Add(prescriptionItemResult.Value);
        return Result.Success(prescriptionItemResult.Value);
    }

    internal Result UpdateItem(
        Id itemId,
        string medicineName,
        decimal dosage,
        MedicineFrequency frequency,
        string? instructions)
    {
        if (_items.Any(i => i.MedicineName == medicineName.Trim() && i.Id != itemId))
        {
            return Result.Failure(
                DomainErrors.Entities.Prescription.Item.MedicineWithTheSameNameAlreadyExists);
        }

        var item = _items
            .FirstOrDefault(p => p.Id == itemId);

        if (item == null)
        {
            return Result.Failure(DomainErrors.Entities.Prescription.Item.NotFound);
        }

        var itemResult = item.Update(
            medicineName,
            dosage,
            frequency,
            instructions);

        if (itemResult.IsFailure)
        {
            return Result.Failure(itemResult.Error);
        }

        return Result.Success();
    }

    internal Result RemoveItem(Id itemId)
    {
        var item = _items
            .FirstOrDefault(p => p.Id == itemId);

        if (item == null)
        {
            return Result.Failure(DomainErrors.Entities.Prescription.Item.NotFound);
        }

        _items.Remove(item);
        return Result.Success();
    }
}