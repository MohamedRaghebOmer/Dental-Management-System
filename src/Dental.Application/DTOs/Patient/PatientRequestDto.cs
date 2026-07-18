using Dental.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Patient;

public sealed record PatientRequestDto()
{
    [Required]
    [StringLength(Domain.ValueObjects.FirstName.MaxLength)]
    public required string FirstName { get; init; }

    [Required]
    [StringLength(Domain.ValueObjects.LastName.MaxLength)]
    public required string LastName { get; init; }

    [Required]
    public required int Age { get; init; }

    [Required]
    public required Gender Gender { get; init; }

    [StringLength(Domain.ValueObjects.PhoneNumber.Length)]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; init; }
}