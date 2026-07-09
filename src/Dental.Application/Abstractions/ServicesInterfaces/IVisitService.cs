using Dental.Application.DTOs.Visit;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitService
{
    Task<Result<int>> CreateAsync(
        CreateVisitDto dto,
        CancellationToken cancellationToken);

    Task<Result> UpdateASync(
        int visitId,
        UpdateVisitDto dto,
        CancellationToken cancellationToken);

    Task<decimal> GetTotalAmountAsync(
        int visitId,
        CancellationToken cancellationToken);
}