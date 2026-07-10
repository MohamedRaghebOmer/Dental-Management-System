using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Visit;

public sealed record VisitRequestDto
{
    [Range(1, int.MaxValue)]
    public int? AppointmentId { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    public required decimal PaidAmount { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    public required decimal DiscountAmount { get; init; }

    [Required]
    public required DateTime Date { get; init; }

    [StringLength(Domain.Entities.Visit.Constants.NotesMaxLength)]
    public string? Notes { get; init; }
}