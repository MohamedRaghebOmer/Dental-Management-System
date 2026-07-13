using Dental.Application.DTOs.VisitToothNumber;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitTreatmentService
{
    Task<Result<int>> CreateAsync(
        VisitTreatmentRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int id,
        VisitTreatmentRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result<VisitTreatmentResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<Result<List<VisitTreatmentResponseDto>>> GetByVisitIdAsync(
        int visitId,
        CancellationToken cancellationToken = default);

    Task<Result<List<VisitTreatmentResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}