using Dental.Application.Abstractions;
using Dental.Domain.Enums;

namespace Dental.Application.DTOs.Appointment;

public sealed record AppointmentResponseDto(
    int id,
    int patientId,
    DateTimeOffset scheduledAt,
    DateTimeOffset? completedAt,
    AppointmentStatus status,
    string? notes) :
    IResponseDto<Domain.Entities.Appointment, AppointmentResponseDto>
{
    public static AppointmentResponseDto ToResponseDto(Domain.Entities.Appointment entity)
    {
        return new AppointmentResponseDto(
            id: entity.Id,
            patientId: entity.PatientId.Value,
            scheduledAt: entity.AppointmentDate,
            completedAt: entity.CompletedAt,
            status: entity.Status,
            notes: entity.Notes
        );
    }
}