namespace Dental.Domain.Views.Patients;

public sealed record PatientInfoCards
{
    public required int PatientsCount { get; init; }
    public required int TodayPatientsCount { get; init; }
    public required decimal MalePatientsPercentage { get; init; }
    public required decimal FemalePatientsPercentage { get; init; }
    public required decimal AdultsPatientsPercentage { get; init; }
    public required decimal ChildrenPatientsPercentage { get; init; }
}