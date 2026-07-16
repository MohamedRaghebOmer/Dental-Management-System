using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Supplier;

public sealed record SupplierRequestDto
{
    [Required]
    [MaxLength(Domain.Entities.Supplier.Constants.NameMaxLength)]
    public required string Name { get; init; }

    [Phone]
    [StringLength(Domain.Entities.Supplier.Constants.PhoneNumberLength),
        MinLength(Domain.Entities.Supplier.Constants.PhoneNumberLength)]
    public string? PhoneNumber { get; init; }

    [MaxLength(Domain.Entities.Supplier.Constants.AddressMaxLength)]
    public string? Address { get; init; }

    [MaxLength(Domain.Entities.Supplier.Constants.DescriptionMaxLength)]
    public string? Description { get; init; }
}