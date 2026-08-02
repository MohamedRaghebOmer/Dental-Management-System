namespace Dental.Application.DTOs.VisitRadioghraph;

public sealed record VisitRadioghraphResponseDto(
    int Id,
    int VisitId,
    string ImagePath
);