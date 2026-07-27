using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Material;

public sealed record MaterialRequestDto
{
    [Required]
    [MaxLength(Domain.Entities.Material.Constants.NameMaxLength)]
    public required string Name { get; init; } = string.Empty;

    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal Quantity { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal ReorderLevel { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal Price { get; init; }
}