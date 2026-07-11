using Dental.Application.DTOs.DentalInfo;
using Dental.Application.DTOs.Prescription;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IPrescriptionService
{
    Task<Result<int>> CreateAsync(PrescriptionRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int prescriptionId,
        PrescriptionRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result<PrescriptionResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);


    Task<Result<IEnumerable<PrescriptionResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}