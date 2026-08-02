using System.ComponentModel.DataAnnotations;

namespace Dental.Application.DTOs.VisitRadioghraph;

public sealed record VisitRadioghraphRequestDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public required int VisitId { get; init; }


    [Required]
    public required string ImagePath { get; init; }
}