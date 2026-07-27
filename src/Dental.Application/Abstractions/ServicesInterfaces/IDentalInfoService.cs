using Dental.Application.DTOs.DentalInfo;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IDentalInfoService
{
    Task<DentalInfoDto> GetAsync(
        CancellationToken cancellationToken = default);

    Task<Result> SetAsync(
        DentalInfoDto dto,
        CancellationToken cancellationToken = default);
}