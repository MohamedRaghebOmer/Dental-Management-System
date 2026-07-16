using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Visit;

public sealed record VisitRequestDto
{
    [Range(1, int.MaxValue)]
    public int? AppointmentId { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal PaidAmount { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal DiscountAmount { get; init; }

    [Required]
    [DataType(DataType.DateTime)]
    public required DateTime VisitDateTime { get; init; }

    [StringLength(Domain.Entities.Visit.Constants.NotesMaxLength)]
    public string? Notes { get; init; }
}