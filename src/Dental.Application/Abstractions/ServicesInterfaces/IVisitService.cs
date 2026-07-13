using Dental.Application.DTOs.Visit;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitService
{
    Task<Result<int>> CreateAsync(
        VisitRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateASync(
        int visitId,
        VisitRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<decimal> GetTotalAmountAsync(
        int visitId,
        CancellationToken cancellationToken = default);

    Task<Result<VisitResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);


    Task<Result<List<VisitResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}