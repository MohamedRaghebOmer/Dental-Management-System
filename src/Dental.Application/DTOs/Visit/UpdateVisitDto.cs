using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Visit;

public sealed record UpdateVisitDto
{
    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal DiscountAmount { get; init; }

    public string? Notes { get; init; } = null;
}