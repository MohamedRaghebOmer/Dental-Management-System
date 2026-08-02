using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class VisitPayment : Entity
{
    public Id VisitId { get; private set; } = default!;
    public Money PaidAmount { get; private set; } = default!;
    public DateTime PaymentDateTime { get; private set; }
    public Visit Visit { get; private set; } = default!;


    private VisitPayment() { } // EF Core

    private VisitPayment(
        Id visitId,
        Money paidAmount)
    {
        VisitId = visitId;
        PaidAmount = paidAmount;
        PaymentDateTime = DateTime.Now;
    }


    internal static Result<VisitPayment> Create(
        Id visitId,
        Money paidAmount)
    {
        var validatResult = Validate(paidAmount);
        if (validatResult.IsFailure)
            return Result.Failure<VisitPayment>(validatResult.Error);

        return new VisitPayment(
            visitId,
            paidAmount);
    }

    internal Result Udpate(Money paidAmount)
    {
        var validateResult = Validate(paidAmount);
        if (validateResult.IsFailure)
            return Result.Failure(validateResult.Error);

        PaidAmount = paidAmount;

        return Result.Success();
    }

    private static Result Validate(Money paidAmount)
    {
        if (paidAmount.Value == 0)
            return Result.Failure(DomainErrors.Entities.VisitPayment.PaidAmount.CanNotBeZero);

        return Result.Success();
    }
}