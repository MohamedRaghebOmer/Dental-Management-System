using Dental.Domain.Enums;

namespace Dental.Domain.Views.Appointment;

public sealed record ShortAppointmentInfo
{
    public int? AppointmentId { get; init; } = null;
    public int? PatientId { get; init; } = null;
    public string? PatientName { get; init; } = null;
    public DateTime? ScheduledVisitDateTime { get; init; } = null;
    public AppointmentStatus? Status { get; init; } = null;
}