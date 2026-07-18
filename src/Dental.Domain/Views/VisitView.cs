namespace Dental.Domain.Views;

public sealed record VisitView
{
    public int? VisitId { get; set; } = null;
    public int? AppointmentId { get; set; } = null;
    public string? PatientName { get; set; } = null;
    public string? VisitTreatmentsNames { get; set; } = null;
    public DateTime? VisitDateTime { get; set; } = null;
    public decimal? TotalAmount { get; set; } = null;
    public decimal? PaidAmount { get; set; } = null;
    public decimal? DiscountAmount { get; set; } = null;
    public decimal? RemainedAmount { get; set; } = null;
}
