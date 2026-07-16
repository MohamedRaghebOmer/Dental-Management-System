using Dental.Application.Abstractions;
using Dental.Domain.Enums;

namespace Dental.Application.DTOs.Appointment;

public sealed record AppointmentResponseDto(
    int id,
    int patientId,
    DateTime createdAt,
    DateTime scheduledAt,
    DateTime? actualVisitDateTime,
    AppointmentStatus status,
    string? notes) :
    IResponseDto<Domain.Entities.Appointment, AppointmentResponseDto>
{
    public static AppointmentResponseDto ToResponseDto(Domain.Entities.Appointment entity)
    {
        return new AppointmentResponseDto(
            id: entity.Id.Value,
            patientId: entity.PatientId.Value,
            createdAt: entity.CreatedAt,
            scheduledAt: entity.ScheduledVisitDateTime,
            actualVisitDateTime: entity.ActualVisitDateTime,
            status: entity.Status,
            notes: entity.Notes
        );
    }
}