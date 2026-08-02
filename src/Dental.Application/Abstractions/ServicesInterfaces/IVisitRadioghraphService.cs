using Dental.Application.DTOs.VisitRadioghraph;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitRadioghraphService
{
    Task<Result<VisitRadioghraphResponseDto>> GetByIdAsync(
        int visitRadioghrapId,
        CancellationToken cancellationToken = default);

    Task<Result<int>> AddAsync(
        VisitRadioghraphRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int visitRadiographId,
        VisitRadioghraphRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(
        int radiographId,
        CancellationToken cancellationToken = default);
}