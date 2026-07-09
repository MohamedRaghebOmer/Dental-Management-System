using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class PrescriptionItem : Entity
{
    private PrescriptionItem() // EF Core
    {
    }

    private PrescriptionItem(
        Id prescriptionId,
        string medicineName,
        decimal dosage,
        MedicineFrequency medicineFrequency,
        string? instructions)
    {
        PrescriptionId = prescriptionId;
        MedicineName = medicineName;
        Dosage = dosage;
        MedicineFrequency = medicineFrequency;
        Instructions = instructions;
    }


    public static class Constants
    {
        public const int MedicineNameMaxLength = 100;
        public const int InstructionsMaxLength = 500;
    }

    public Id PrescriptionId { get; private set; } = default!;
    public string MedicineName { get; private set; }
    public decimal Dosage { get; private set; }
    public MedicineFrequency MedicineFrequency { get; private set; }
    public string? Instructions { get; private set; }

    public Prescription Prescription { get; private set; } = default!;


    public static Result<PrescriptionItem> Create(
        Id prescriptionId,
        string medicineName,
        decimal dosage,
        MedicineFrequency medicineFrequency,
        string? instructions)
    {
        var validateResult = Validate(
            medicineName,
            dosage,
            instructions);

        if (validateResult.IsFailure)
        {
            return Result.Failure<PrescriptionItem>(validateResult.Error);
        }

        return new PrescriptionItem(
            prescriptionId, medicineName.Trim(), dosage, medicineFrequency, instructions?.Trim());
    }

    public Result Update(
        Id prescriptionId,
        string medicineName,
        decimal dosage,
        MedicineFrequency medicineFrequency,
        string? instructions)
    {
        var validateResult = Validate(
            medicineName,
            dosage,
            instructions);

        if (validateResult.IsFailure)
        {
            return Result.Failure<PrescriptionItem>(validateResult.Error);
        }

        PrescriptionId = prescriptionId;
        MedicineName = medicineName.Trim();
        Dosage = dosage;
        MedicineFrequency = medicineFrequency;
        Instructions = instructions?.Trim();

        return Result.Success();
    }

    private static Result Validate(
        string medicineName,
        decimal dosage,
        string? instructions)
    {
        if (string.IsNullOrWhiteSpace(medicineName))
        {
            return Result.Failure(
                DomainErrors.Entities.PrescriptionItems.MedicineName.Required);
        }

        medicineName = medicineName.Trim();

        if (medicineName.Length > Constants.MedicineNameMaxLength)
        {
            return Result.Failure(
                DomainErrors.Entities.PrescriptionItems.MedicineName.TooLong);
        }

        if (dosage <= 0)
        {
            return Result.Failure(
                DomainErrors.Entities.PrescriptionItems.Dosage.MustBePositive);
        }

        instructions = instructions?.Trim();

        if (instructions?.Length > Constants.InstructionsMaxLength)
        {
            return Result.Failure(
                DomainErrors.Entities.PrescriptionItems.Instructions.TooLong);
        }

        return Result.Success();
    }
}