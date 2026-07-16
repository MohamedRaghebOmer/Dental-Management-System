using Dental.Application.DTOs.DentalInfo;
using Dental.Application.DTOs.Patient;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IPatientService
{
    Task<Result<int>> CreateAsync(
        PatientRequestDto requestDto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int patientId,
        PatientRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result<PatientResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);


    Task<List<PatientResponseDto>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}