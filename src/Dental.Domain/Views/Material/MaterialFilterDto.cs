using Dental.Domain.Enums;

namespace Dental.Domain.Views.Material;

public sealed record MaterialFilterDto
{
    public int? Id { get; init; } = null;
    public string? Name { get; init; } = null;
    public decimal? Quantity { get; init; } = null;
    public decimal? ReorderLevel { get; init; } = null;
    public decimal? Price { get; init; } = null;
    public MaterialStatus? Status { get; init; } = null;
}