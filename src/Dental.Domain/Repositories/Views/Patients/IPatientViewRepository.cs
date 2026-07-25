using Dental.Domain.Views.Patients;

namespace Dental.Domain.Repositories.Views.Patients;

public interface IPatientViewRepository
{
    Task<List<PatientViewDto>> GetAsync(
        PatientViewDto? filterDto = null,
        CancellationToken cancellationToken = default);
}