using Dental.Application.ViewsStuff.Interfaces.Patients;
using Dental.Domain.Repositories.Views.Patients;
using Dental.Domain.Views.Patients;

namespace Dental.Application.ViewsStuff.Services.Patients;

public sealed class PatientViewService(IPatientViewRepository _repo) : IPatientViewService
{
    public Task<List<PatientViewDto>> GetAsync(
        PatientViewDto? filterDto = null,
        CancellationToken cancellationToken = default)
    {
        return _repo.GetAsync(filterDto, cancellationToken);
    }
}