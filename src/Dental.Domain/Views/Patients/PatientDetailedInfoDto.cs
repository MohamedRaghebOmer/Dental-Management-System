using Dental.Domain.Enums;

namespace Dental.Domain.Views.Patients;

public sealed record PatientDetailedInfoDto
{
    public int? Id { get; set; } = null;
    public string? Name { get; set; } = null;
    public int? Age { get; set; } = null;
    public Gender? Gender { get; set; } = null;
    public string? PhoneNumber { get; set; } = null;
    public DateTime? NextAppointmentDateTime { get; set; } = null;
    public DateTime? LastVisitDateTime { get; set; } = null;
    public int? TotalNumberOfVisits { get; set; } = null;
}