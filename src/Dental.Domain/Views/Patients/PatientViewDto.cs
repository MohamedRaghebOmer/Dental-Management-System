using Dental.Domain.Enums;

namespace Dental.Domain.Views.Patients;

public sealed record PatientViewDto
{
    public int? Id { get; set; } = null;
    public string? Name { get; set; } = null;
    public int? Age { get; set; } = null;
    public Gender? Gender { get; set; } = null;
    public string? PhoneNumber { get; set; } = null;
}