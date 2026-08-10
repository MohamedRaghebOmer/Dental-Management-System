using Dental.Application.Abstractions;
using Dental.Domain.ValueObjects;

namespace Dental.Application.DTOs.VisitTreatments;

public sealed record VisitTreatmentResponseDto(
    int Id,
    int VisitId,
    int TreatmentId,
    ToothNumber? ToothNumber,
    decimal TreatmentPrice,
    int Count,
    decimal TotalPrice,
    string? Notes)
    : IResponseDto<Domain.Entities.VisitTreatment, VisitTreatmentResponseDto>
{
    public static VisitTreatmentResponseDto ToResponseDto(
        Domain.Entities.VisitTreatment entity)
    {
        return new VisitTreatmentResponseDto(
            Id: entity.Id.Value,
            VisitId: entity.VisitId.Value,
            TreatmentId: entity.TreatmentId.Value,
            ToothNumber: entity.ToothNumber,
            TreatmentPrice: entity.TreatmentPrice.Value,
            Count: entity.Count,
            TotalPrice: entity.TotalPrice,
            Notes: entity.Notes
        );
    }
}