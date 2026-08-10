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
        Money paidAmount,
        DateTime paymentDateTime)
    {
        VisitId = visitId;
        PaidAmount = paidAmount;
        PaymentDateTime = paymentDateTime;
    }


    internal static Result<VisitPayment> Create(
        Id visitId,
        Money paidAmount,
        DateTime paymentDateTime)
    {
        var validatResult = Validate(paidAmount, paymentDateTime);
        if (validatResult.IsFailure)
            return Result.Failure<VisitPayment>(validatResult.Error);

        return new VisitPayment(
            visitId,
            paidAmount,
            paymentDateTime);
    }

    internal Result Update(Money paidAmount, DateTime paymentDateTime)
    {
        var validateResult = Validate(paidAmount, paymentDateTime);
        if (validateResult.IsFailure)
            return Result.Failure(validateResult.Error);

        PaidAmount = paidAmount;
        PaymentDateTime = paymentDateTime;

        return Result.Success();
    }

    private static Result Validate(Money paidAmount, DateTime paymentDateTime)
    {
        if (paidAmount.Value == 0)
            return Result.Failure(DomainErrors.Entities.VisitPayment.PaidAmount.CanNotBeZero);

        if (paymentDateTime > DateTime.Now)
            return Result.Failure(
                DomainErrors.Entities.VisitPayment.PaymentDateTime.CanNotBeInTheFuture);

        return Result.Success();
    }
}