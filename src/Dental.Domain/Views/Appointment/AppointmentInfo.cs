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
    public int? Id { get; set; } = null;
    public int? PatientId { get; set; } = null;
    public string? PatientName { get; set; } = null;
    public DateTime? CreatedAt { get; set; } = null;
    public DateTime? ScheduledVisitDateTime { get; set; } = null;
    public DateTime? ActualVisitDateTime { get; set; } = null;
    public AppointmentStatus? Status { get; set; } = null;
    public string? Notes { get; set; } = null;


    /// <summary>
    /// When 'CreatedAt' is not null (has a value), then ignore this property and use 'CreatedAt' instead.
    /// When 'CreatedAt' is null, then use this property to filter appointments created after this date.
    /// </summary>
    public DateTime? GetAfter { get; set; } = null;
}