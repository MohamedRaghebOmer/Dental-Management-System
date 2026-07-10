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

    public DateOnly? DateOfBirth { get; init; }

    [Required]
    public required Gender Gender { get; init; }

    [StringLength(Domain.ValueObjects.PhoneNumber.Length)]
    public string? PhoneNumber { get; init; }

    [StringLength(Domain.Entities.Patient.Constants.AddressMaxLength)]
    public string? Address { get; init; }
}