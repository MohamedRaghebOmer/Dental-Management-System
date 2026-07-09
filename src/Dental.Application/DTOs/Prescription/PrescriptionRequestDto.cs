using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Prescription;

public sealed record PrescriptionRequestDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "PatientId must be greater than 0.")]
    public required int PatientId { get; init; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "VisitId must be greater than 0.")]
    public required int VisitId { get; init; }

    [MaxLength(Domain.Entities.Prescription.Constants.NotesMaxLength)]
    public string? Notes { get; init; }
}