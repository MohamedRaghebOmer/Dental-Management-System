using Dental.Application.Abstractions;
using Dental.Domain.Enums;

namespace Dental.Application.DTOs.Appointment;

public sealed record AppointmentResponseDto(
    int Id,
    int PatientId,
    DateTime CreatedAt,
    DateTime ScheduledVisitDateTime,
    DateTime? ActualVisitDateTime,
    AppointmentStatus Status,
    string? Notes) :
    IResponseDto<Domain.Entities.Appointment, AppointmentResponseDto>
{
    public static AppointmentResponseDto ToResponseDto(Domain.Entities.Appointment entity)
    {
        return new AppointmentResponseDto(
            Id: entity.Id.Value,
            PatientId: entity.PatientId.Value,
            CreatedAt: entity.CreatedAt,
            ScheduledVisitDateTime: entity.ScheduledVisitDateTime,
            ActualVisitDateTime: entity.ActualVisitDateTime,
            Status: entity.Status,
            Notes: entity.Notes
        );
    }
}