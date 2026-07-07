using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Service;

public sealed record UpdateServiceDto
{
    [Range(1, int.MaxValue)]
    public int Id { get; init; }

    [StringLength(Domain.Entities.Service.NameMaxLength, MinimumLength = 2)]
    public string? Name { get; init; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; init; }

    [StringLength(Domain.Entities.Service.DescriptionMaxLength)]
    public string? Description { get; init; }
}