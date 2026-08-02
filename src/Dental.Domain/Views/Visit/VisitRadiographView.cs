namespace Dental.Domain.Views.Visit;

public record VisitRadiographView
{
    public int? VisitId { get; init; } = null;
    public string? PatientName { get; init; } = null;
    public DateTime? RadiographCreatedAt { get; init; } = null;
    public int? PatientId { get; init; } = null;
    public int? VisitRadiographId { get; init; } = null;
    public string? ImagePath { get; init; } = null;
    public DateTime? FilterAfter { get; init; } = null;
}