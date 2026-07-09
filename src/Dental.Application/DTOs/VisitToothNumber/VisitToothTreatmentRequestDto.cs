using Dental.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.VisitToothNumber;

public sealed record VisitToothTreatmentRequestDto
{
    [Range(1, 32)]
    [Required]
    public required byte ToothNumber { get; init; }

    [Range(1, int.MaxValue)]
    [Required]
    public required int VisitId { get; init; }

    [Range(1, int.MaxValue)]
    [Required]
    public required int ServiceId { get; init; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to zero.")]
    [DataType(DataType.Currency)]
    public required decimal Price { get; init; }

    [MaxLength(VisitToothTreatment.Constants.NotesMaxLength)]
    public string? Notes { get; init; } = null;
}