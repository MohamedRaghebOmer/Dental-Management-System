using Dental.Domain.Views.Patients;

namespace Dental.Application.ViewsStuff.Interfaces.Patients;

public interface IPatientViewService
{
    Task<List<PatientViewDto>> GetAsync(
        PatientViewDto? filterDto = null,
        CancellationToken cancellationToken = default);
}