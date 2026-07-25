using Dental.Domain.Enums;

namespace Dental.Domain.Views.Appointment;

//public sealed record AppointmentInfo(
//    int Id,
//    int PatientId,
//    string PatientName,
//    DateTime CreatedAt,
//    DateTime ScheduledVisitDateTime,
//    DateTime? ActualVisitDateTime,
//    AppointmentStatus Status,
//    string? Notes);


public sealed record AppointmentInfo
{
    public int? Id { get; init; } = null;
    public int? PatientId { get; init; } = null;
    public string? PatientName { get; init; } = null;
    public DateTime? CreatedAt { get; init; } = null;
    public DateTime? ScheduledVisitDateTime { get; init; } = null;
    public DateTime? ActualVisitDateTime { get; init; } = null;
    public AppointmentStatus? Status { get; init; } = null;
    public string? Notes { get; init; } = null;


    /// <summary>
    /// When 'CreatedAt' is not null (has a value), then ignore this property and use 'CreatedAt' instead.
    /// When 'CreatedAt' is null, then use this property to filter appointments created after this date.
    /// </summary>
    public DateTime? GetAfter { get; init; } = null;
}