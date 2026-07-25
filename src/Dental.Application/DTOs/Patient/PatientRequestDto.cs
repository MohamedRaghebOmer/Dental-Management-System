using Dental.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Patient;

public sealed record PatientRequestDto()
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required int Age { get; init; }

    [Required]
    public required Gender Gender { get; init; }

    [StringLength(Domain.ValueObjects.PhoneNumber.Length)]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; init; }
}