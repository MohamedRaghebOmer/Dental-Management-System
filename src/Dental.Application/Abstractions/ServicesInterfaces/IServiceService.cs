using Dental.Application.DTOs.Responses;
using Dental.Application.DTOs.Service;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IServiceService
{
    Task<Result<int>> CreateAsync(
        CreateServiceDto? dto,
        CancellationToken cancellationToken = default);

    Task<Result<ServiceResponseDto>> UpdateAsync(
        int id,
        UpdateServiceDto dto,
        CancellationToken cancellationToken = default);
}