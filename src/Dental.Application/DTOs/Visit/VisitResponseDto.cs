using Dental.Application.Abstractions;
using Dental.Domain.ValueObjects;

namespace Dental.Application.DTOs.Visit;

public sealed record VisitResponseDto(
    int Id,
    Id? AppointmentId,
    Money PaidAmount,
    Money DiscountAmount,
    DateTime VisitDateTime,
    string? Notes)
    : IResponseDto<Domain.Entities.Visit, VisitResponseDto>
{
    public static VisitResponseDto ToResponseDto(Domain.Entities.Visit entity)
    {
        return new VisitResponseDto(
            Id: entity.Id.Value,
            AppointmentId: entity.AppointmentId,
            PaidAmount: entity.PaidAmount,
            DiscountAmount: entity.DiscountAmount,
            VisitDateTime: entity.VisitDateTime,
            Notes: entity.Notes
        );
    }
}