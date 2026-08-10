using Dental.Application.Abstractions;
using Dental.Domain.Enums;

namespace Dental.Application.DTOs.Patient;

public sealed record PatientResponseDto(
    int Id,
    string Name,
    int? Age,
    Gender Gender,
    string? PhoneNumber)
    : IResponseDto<Domain.Entities.Patient, PatientResponseDto>
{
    public PatientResponseDto(Domain.Entities.Patient entity)
    : this(
        entity.Id.Value,
        entity.Name,
        entity.Age,
        entity.Gender,
        entity.PhoneNumber?.Value)
    { }

    public static PatientResponseDto ToResponseDto(Domain.Entities.Patient entity)
    {
        return new PatientResponseDto(entity);
    }
}