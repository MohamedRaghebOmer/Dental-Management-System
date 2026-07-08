using Dental.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Patient;

public sealed record UpdatePatientDto
{
    [StringLength(Domain.ValueObjects.FirstName.MaxLength)]
    public required string FirstName { get; init; }

    [StringLength(Domain.ValueObjects.LastName.MaxLength)]
    public required string LastName { get; init; }

    public DateOnly? DateOfBirth { get; init; }

    public required Gender Gender { get; init; }

    [StringLength(Domain.ValueObjects.PhoneNumber.Length)]
    public string? PhoneNumber { get; init; }

    [StringLength(Domain.Entities.Patient.Constants.AddressMaxLength)]
    public string? Address { get; init; }
}