namespace Dental.Domain.Views.LabTransactions;

public sealed record LabTransactionFilterDto
{
    public int? Id { get; set; } = null;
    public string? LabName { get; set; } = null;
    public DateTime? TranDateTime { get; set; } = null;
    public decimal? PaidAmount { get; set; } = null;
    public decimal? TotalAmount { get; set; } = null;
    public decimal? RemainingAmount { get; set; } = null;
    public string? Treatments { get; set; } = null;

    /// <summary>
    /// If 'TranDateTime' is not null, then ignore 'GetAfter' and use 'TranDateTime' for filtering.
    /// If 'TranDateTime' is null, then use 'GetAfter' for filtering.
    /// </summary>
    public DateTime? GetAfter { get; set; } = null;
}