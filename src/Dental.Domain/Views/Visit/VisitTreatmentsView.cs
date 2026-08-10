namespace Dental.Domain.Views.Visit;

public sealed record VisitTreatmentsView
{

    /*
                    (VisitTreatmentsView)

    - VisitTreatments<VisitId>.ToothNumber
    - Treatments<VisitTreatments<VisitId>>.TreatmentName
    - VisitTreatments<VisitId>.TreatmentPrice
    - VisitTreatments<VisitId>.Notes



     */


    public byte? ToothNumber { get; init; } = null;
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required int Count { get; init; }
    public required decimal TotalPrice { get; init; }
    public string? Notes { get; init; } = null;
}