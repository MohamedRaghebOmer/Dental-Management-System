using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class LabTransaction : Entity
{
    public static class Constants
    {
        public const int LabNameMaxLength = 100;
        public const int TreatmentsMaxLength = 1000;
    }

    public string LabName { get; private set; } = string.Empty;
    public DateTime TranDateTime { get; private set; }
    public Money PaidAmount { get; private set; } = default!;
    public Money TotalAmount { get; private set; } = default!;
    public decimal RemainingAmount => TotalAmount.Value - PaidAmount.Value;
    public string? Treatments { get; private set; }


    private LabTransaction() { } // EF Core

    private LabTransaction(
        string labName,
        DateTime tranDateTime,
        Money paidAmount,
        Money totalAmount,
        string? treatments)
    {
        LabName = labName;
        TranDateTime = tranDateTime;
        PaidAmount = paidAmount;
        TotalAmount = totalAmount;
        Treatments = treatments;
    }


    public static Result<LabTransaction> Create(
        string labName,
        Money paidAmount,
        Money totalAmount,
        string? treatments)
    {
        labName = labName.Trim();
        treatments = treatments?.Trim();

        var validateResult =
            Validate(labName, treatments);
        if (validateResult.IsFailure)
        {
            return Result.Failure<LabTransaction>(validateResult.Error);
        }

        return new LabTransaction(labName, DateTime.Now, paidAmount, totalAmount, treatments);
    }

    public Result Update(
        string labName,
        Money paidAmount,
        Money totalAmount,
        string? treatments)
    {
        labName = labName.Trim();
        treatments = treatments?.Trim();

        var validateResult =
            Validate(labName, treatments);
        if (validateResult.IsFailure)
        {
            return Result.Failure(validateResult.Error);
        }

        LabName = labName;
        PaidAmount = paidAmount;
        TotalAmount = totalAmount;
        Treatments = treatments;

        return Result.Success();
    }

    private static Result Validate(
        string labName,
        string? treatments)
    {
        if (string.IsNullOrWhiteSpace(labName))
            return Result.Failure(DomainErrors.Entities.LabTransaction.LabName.Empty);

        if (labName.Length > Constants.LabNameMaxLength)
            return Result.Failure(DomainErrors.Entities.LabTransaction.LabName.TooLong);

        if (treatments?.Length > Constants.TreatmentsMaxLength)
            return Result.Failure(DomainErrors.Entities.LabTransaction.Treatments.TooLong);

        return Result.Success();
    }
}