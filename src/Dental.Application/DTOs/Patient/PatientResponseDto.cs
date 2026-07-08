using Dental.Application.Abstractions;
using Dental.Domain.Enums;

namespace Dental.Application.DTOs.Patient;

public sealed record PatientResponseDto(
    int id,
    string firstName,
    string lastName,
    string fullName,
    DateOnly? birthDate,
    int? age,
    Gender gender,
    string? phoneNumber,
    string? address)
    : IResponseDto<Domain.Entities.Patient, PatientResponseDto>
{
    public PatientResponseDto(Domain.Entities.Patient entity)
    : this(
        entity.Id,
        entity.FirstName.Value,
        entity.LastName.Value,
        entity.FullName,
        entity.DateOfBirth?.Value,
        entity.Age,
        entity.Gender,
        entity.PhoneNumber?.Value,
        entity.Address)
    { }

    public static PatientResponseDto ToResponseDto(Domain.Entities.Patient entity)
    {
        return new PatientResponseDto(entity);
    }
}