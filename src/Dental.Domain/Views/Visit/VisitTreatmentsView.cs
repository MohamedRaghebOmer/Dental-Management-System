namespace Dental.Domain.Views.Visit;

public sealed record VisitTreatmentsView
{

    /*
                    (VisitTreatmentsView)

    - VisitTreatments<VisitId>.ToothNumber
    - Treatments<VisitTreatments<VisitId>>.TreatmentName
    - VisitTreatments<VisitId>.Price
    - VisitTreatments<VisitId>.Notes



     */


    public required byte ToothNumber { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public string? Notes { get; init; }
}