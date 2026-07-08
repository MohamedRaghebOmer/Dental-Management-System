using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Visit;

public record UpdateVisitDto
{
    [Range(1, int.MaxValue)]
    public int? AppointmentId { get; init; }

    [Range(0, double.MaxValue)]
    public required decimal PaidAmount { get; init; }

    [Range(0, double.MaxValue)]
    public required decimal DiscountAmount { get; init; }

    [Range(0, double.MaxValue)]
    public required decimal TotalAmount { get; init; }

    public required DateTime Date { get; init; }

    [StringLength(Domain.Entities.Visit.Constants.NotesMaxLength)]
    public string? Notes { get; init; }
}