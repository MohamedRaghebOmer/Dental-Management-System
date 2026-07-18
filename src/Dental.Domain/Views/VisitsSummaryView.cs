namespace Dental.Domain.Views;

public sealed record VisitsSummaryView
{
    public required int TotalVisitsCount { get; init; }
    public required decimal TotalVisitsTotalAmount { get; init; }
    public required decimal TotalVisitsPaidAmount { get; init; }
    public required decimal TotalVisitsDiscountAmount { get; init; }
    public required decimal TotalVisitsRemainedAmount { get; init; }
}
