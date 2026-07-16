using Dental.Application.DTOs.Treatment;
using Dental.Application.DTOs.VisitToothNumber;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface ITreatmentService
{
    Task<Result<int>> CreateAsync(
        TreatmentRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int id,
        TreatmentRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result<TreatmentResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);


    Task<List<TreatmentResponseDto>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}