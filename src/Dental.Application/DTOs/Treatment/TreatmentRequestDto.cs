using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.Treatment;

public sealed record TreatmentRequestDto
{
    [StringLength(Domain.Entities.Treatment.Constants.NameMaxLength, MinimumLength = 2)]
    public required string Name { get; init; }

    [Range(0, double.MaxValue)]
    public required decimal Price { get; init; }

    [StringLength(Domain.Entities.Treatment.Constants.DescriptionMaxLength)]
    public string? Description { get; init; }
}