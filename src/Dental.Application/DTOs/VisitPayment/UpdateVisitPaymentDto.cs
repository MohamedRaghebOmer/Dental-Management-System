using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.VisitPayment;

public sealed record UpdateVisitPaymentDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public required int Id { get; init; }

    [Required]
    [Range(1, int.MaxValue)]
    public required int VisitId { get; init; }

    [Required]
    [DataType(DataType.Currency)]
    [Range(1, double.MaxValue)]
    public required decimal PaidAmount { get; init; }

    [Required]
    [DataType(DataType.DateTime)]
    public required DateTime PaymentDateTime { get; init; }
}