using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Visit;

public sealed record WalkInVisitDto
{
    [Range(1, int.MaxValue)]
    [Required]
    public required int PatientId { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal PaidAmount { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal DiscountAmount { get; init; }

    public string? Notes { get; init; }
}