using Dental.Application.Abstractions;
using Dental.Domain.ValueObjects;

namespace Dental.Application.DTOs.Prescription;

public sealed record PrescriptionResponseDto(
    int id,
    Id visitId,
    string? notes)
    : IResponseDto<Domain.Entities.Prescription, PrescriptionResponseDto>
{
    public static PrescriptionResponseDto ToResponseDto(Domain.Entities.Prescription entity)
    {
        return new PrescriptionResponseDto(
            entity.Id.Value,
            entity.VisitId,
            entity.Notes);
    }
}