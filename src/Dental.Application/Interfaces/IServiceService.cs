using Dental.Application.DTOs.Responses;
using Dental.Application.DTOs.Service;
using Dental.Domain.Shared;

namespace Dental.Application.Interfaces;

public interface IServiceService
{
    Task<Result<int>> CreateServiceAsync(
        CreateServiceDto dto,
        CancellationToken cancellationToken = default);

    Task<Result<ServiceResponseDto?>> GetServiceByIdAsync(int id,
        CancellationToken cancellationToken = default);

    Task<Result<IEnumerable<ServiceResponseDto>>> ListServicesAsync(
        CancellationToken cancellationToken = default);

    Task<Result<ServiceResponseDto>> UpdateServiceAsync(
        UpdateServiceDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> DeleteServiceAsync(
        int id,
        CancellationToken cancellationToken = default);
}