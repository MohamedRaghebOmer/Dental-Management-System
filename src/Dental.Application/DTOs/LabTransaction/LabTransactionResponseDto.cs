using Dental.Application.Abstractions;

namespace Dental.Application.DTOs.LabTransaction;

public sealed record LabTransactionResponseDto
    : IResponseDto<Domain.Entities.LabTransaction, LabTransactionResponseDto>
{
    public int Id { get; set; }
    public string LabName { get; set; } = string.Empty;
    public DateTime TranDateTime { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public string? Treatments { get; set; } = null;


    public static LabTransactionResponseDto ToResponseDto(Domain.Entities.LabTransaction entity)
    {
        return new LabTransactionResponseDto
        {
            Id = entity.Id.Value,
            LabName = entity.LabName,
            TranDateTime = entity.TranDateTime,
            PaidAmount = entity.PaidAmount.Value,
            TotalAmount = entity.TotalAmount.Value,
            RemainingAmount = entity.RemainingAmount,
            Treatments = entity.Treatments
        };
    }
}