using Dental.Domain.Entities;

namespace Dental.Application.DTOs.VisitRadioghraph;

public sealed record VisitRadioghraphResponseDto(
    int Id,
    int VisitId,
    string ImagePath,
    DateTime CreatedAt)
{
    public static VisitRadioghraphResponseDto ToResponseDto(VisitRadiograph radiograph)
    {
        return new VisitRadioghraphResponseDto(
            radiograph.Id.Value,
            radiograph.VisitId.Value,
            radiograph.ImagePath,
            radiograph.CreatedAt);
    }
}