namespace Dental.Application.DTOs.LabTransaction;

public sealed record LabTransactionRequestDto
{
    public required string LabName { get; init; }
    public required decimal PaidAmount { get; init; }
    public required decimal TotalAmount { get; init; }
    public string? Treatments { get; init; } = null;
}