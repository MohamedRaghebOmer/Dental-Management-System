using Dental.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.PrescriptionItem;

public sealed record PrescriptionItemRequestDto
{
    [Required]
    [MaxLength(Domain.Entities.PrescriptionItem.Constants.MedicineNameMaxLength)]
    public required string MedicineName { get; init; }

    [Required]
    [Range(1, double.MaxValue)]
    [DataType(DataType.Currency, ErrorMessage = "Invalid dosage amount.")]
    public required decimal Dosage { get; init; }

    [Required]
    [Range(1, int.MaxValue)]
    public required int MedicineFrequency { get; init; }

    [Required]
    public required MedicinePeriodFrequency PeriodFrequency { get; init; }

    [MaxLength(Domain.Entities.PrescriptionItem.Constants.InstructionsMaxLength)]
    public string? Instructions { get; init; }
}