using Dental.Application.Abstractions;

namespace Dental.Application.DTOs.VisitPayment;

public sealed record VisitPaymentResponseDto(
    int VisitPaymentId,
    int VisitId,
    decimal PaidAmount,
    DateTime PaymentDateTime)
    : IResponseDto<Domain.Entities.VisitPayment, VisitPaymentResponseDto>
{
    public static VisitPaymentResponseDto ToResponseDto(Domain.Entities.VisitPayment entity)
    {
        return new VisitPaymentResponseDto(
            entity.Id.Value,
            entity.VisitId.Value,
            entity.PaidAmount.Value,
            entity.PaymentDateTime);
    }
}