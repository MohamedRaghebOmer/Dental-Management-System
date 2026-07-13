using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Prescription : Entity
{
    private Prescription() { }  // EF Core

    private Prescription(
        string? notes)
    {
        this.Notes = notes?.Trim();
    }

    public static class Constants
    {
        public const int NotesMaxLength = 500;
    }

    public string? Notes { get; private set; }


    public Visit Visit { get; private set; } = default!;
    public IReadOnlyCollection<PrescriptionItem> Items => _items.AsReadOnly();
    private readonly List<PrescriptionItem> _items = [];


    internal static Result<Prescription> Create(string? notes)
    {
        var validateResult = Validate(notes);
        if (!validateResult.IsSuccess)
        {
            return Result.Failure<Prescription>(validateResult.Error);
        }

        return new Prescription(notes?.Trim());
    }

    internal Result Update(string? notes)
    {
        var validateResult = Validate(notes);
        if (!validateResult.IsSuccess)
        {
            return Result.Failure(validateResult.Error);
        }

        this.Notes = notes?.Trim();

        return Result.Success();
    }

    private static Result Validate(string? notes)
    {
        if (notes?.Trim().Length > Constants.NotesMaxLength)
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
        medicineName = medicineName.Trim();
        if (_items.Any(i => i.MedicineName == medicineName))
        {
            return Result.Failure<PrescriptionItem>(DomainErrors.Entities.Prescription.Item.MedicineWithTheSameNameAlreadyExists);
        }

        var prescriptionItemResult = PrescriptionItem.Create(
            this.Id,
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
        medicineName = medicineName.Trim();

        if (_items.Any(i => i.MedicineName == medicineName && i.Id != itemId))
        {
            return Result.Failure(DomainErrors.Entities.Prescription.Item.MedicineWithTheSameNameAlreadyExists);
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