using Dental.Application.Abstractions;

namespace Dental.Application.DTOs.Visit;

public sealed record VisitResponseDto(
    int Id,
    int? AppointmentId,
    string? PatientName,
    decimal PaidAmount,
    decimal DiscountAmount,
    DateTime VisitDateTime,
    string? Notes)
    : IResponseDto<Domain.Entities.Visit, VisitResponseDto>
{
    public static VisitResponseDto ToResponseDto(Domain.Entities.Visit entity)
    {
        return new VisitResponseDto(
            Id: entity.Id.Value,
            AppointmentId: entity.AppointmentId?.Value,
            PatientName: entity.PatientName,
            PaidAmount: entity.PaidAmount.Value,
            DiscountAmount: entity.DiscountAmount.Value,
            VisitDateTime: entity.VisitDateTime,
            Notes: entity.Notes
        );
    }
}