using Dental.Application.Abstractions;
using Dental.Domain.ValueObjects;

namespace Dental.Application.DTOs.VisitToothNumber;

public sealed record VisitToothTreatmentResponseDto(
    int Id,
    ToothNumber ToothNumber,
    int VisitId,
    int ServiceId,
    decimal Price,
    string? Notes)
    : IResponseDto<Domain.Entities.VisitToothTreatment, VisitToothTreatmentResponseDto>
{
    public static VisitToothTreatmentResponseDto ToResponseDto(
        Domain.Entities.VisitToothTreatment entity)
    {
        return new VisitToothTreatmentResponseDto(
            Id: entity.Id,
            ToothNumber: entity.ToothNumber,
            VisitId: entity.VisitId.Value,
            ServiceId: entity.ServiceId.Value,
            Price: entity.Price.Value,
            Notes: entity.Notes
        );
    }
}