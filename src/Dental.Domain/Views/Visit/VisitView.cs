namespace Dental.Domain.Views.Visit;

public sealed record VisitView
{
    public int? VisitId { get; set; } = null;
    public int? AppointmentId { get; set; } = null;
    public int? PatientId { get; set; } = null;
    public string? PatientName { get; set; } = null;
    public string? VisitTreatmentsNames { get; set; } = null;
    public DateTime? VisitDateTime { get; set; } = null;
    public decimal? TotalAmount { get; set; } = null;
    public decimal? SumOfPaidAmounts { get; set; } = null;
    public decimal? DiscountAmount { get; set; } = null;
    public decimal? RemainedAmount { get; set; } = null;

    /// <summary>
    /// Used to filter the visits based on a specific date and time.
    /// Used only if 'VisitDateTime' is null, otherwise ignore it's value and use 'VisitDateTime'
    /// If this property is set, only visits that occurred after the specified date and time will be included in the view.
    /// </summary>
    public DateTime? GetViewsAfterDateTime { get; set; } = null;
}
