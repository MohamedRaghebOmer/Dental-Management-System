using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Service;

public sealed record CreateServiceDto
{
    [StringLength(Domain.Entities.Service.NameMaxLength, MinimumLength = 2)]
    public required string Name { get; init; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; init; }

    [StringLength(Domain.Entities.Service.DescriptionMaxLength)]
    public string? Description { get; init; }
}