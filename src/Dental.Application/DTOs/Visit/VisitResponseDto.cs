using Dental.Application.Abstractions;
using Dental.Domain.ValueObjects;

namespace Dental.Application.DTOs.Visit;

public sealed record VisitResponseDto(
    int Id,
    Id? AppointmentId,
    Money PaidAmount,
    Money DiscountAmount,
    Money TotalAmount,
    DateTime Date,
    string? Notes)
    : IResponseDto<Domain.Entities.Visit, VisitResponseDto>
{
    public static VisitResponseDto ToResponseDto(Domain.Entities.Visit entity)
    {
        return new VisitResponseDto(
            Id: entity.Id,
            AppointmentId: entity.AppointmentId,
            PaidAmount: entity.PaidAmount,
            DiscountAmount: entity.DiscountAmount,
            TotalAmount: entity.TotalAmount,
            Date: entity.Date,
            Notes: entity.Notes
        );
    }
}