using Dental.Application.DTOs.Patient;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IPatientService
{
    Task<Result<int>> CreateAsync(
        CreatePatientDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int patientId,
        UpdatePatientDto dto,
        CancellationToken cancellationToken = default);
}