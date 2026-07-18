using Dental.Application.DTOs.DentalInfo;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IDentalInfoService
{
    Task<Result<DentalInfoDto>> UpdateAsync(
        DentalInfoDto dto,
        CancellationToken cancellationToken = default);

    Task<Result<DentalInfoDto>> GetAsync(
        CancellationToken cancellationToken = default);
}