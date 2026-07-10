using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Material;

public sealed record MaterialRequestDto
{
    [Required]
    [MaxLength(Domain.Entities.Material.Constants.NameMaxLength)]
    public required string Name { get; init; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int? SupplierId { get; init; } = null;

    [Required]
    [Range(1, int.MaxValue)]
    public required int ReorderLevel { get; init; }

    [MaxLength(Domain.Entities.Material.Constants.DescriptionMaxLength)]
    public string? Description { get; init; }

    [Required]
    [Range(0, int.MaxValue)]
    public required int Quantity { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    public required decimal BuyingPrice { get; init; }
}