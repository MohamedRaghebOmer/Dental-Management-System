using Dental.Application.DTOs.Visit;
using Dental.Application.DTOs.VisitToothNumber;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitService
{
    Task<Result<int>> CreateAsync(
        VisitRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int visitId,
        VisitRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result<VisitResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);


    Task<List<VisitResponseDto>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}