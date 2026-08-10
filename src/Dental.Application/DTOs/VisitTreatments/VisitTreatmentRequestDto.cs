using Dental.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.VisitTreatments;

public sealed record VisitTreatmentRequestDto
{
    [Range(1, int.MaxValue)]
    [Required]
    public required int VisitId { get; init; }

    [Range(1, int.MaxValue)]
    [Required]
    public required int TreatmentId { get; init; }

    [Range(1, 32)]
    [Required]
    public required byte ToothNumber { get; init; }

    [Range(1, int.MaxValue)]
    public int Count { get; init; } = 1;

    [MaxLength(VisitTreatment.Constants.NotesMaxLength)]
    public string? Notes { get; init; } = null;
}