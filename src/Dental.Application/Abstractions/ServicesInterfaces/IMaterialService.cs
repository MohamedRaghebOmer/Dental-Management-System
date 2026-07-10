using Dental.Application.DTOs.Material;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IMaterialService
{
    Task<Result<int>> CreateAsync(MaterialRequestDto requestDto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int materialId,
        MaterialRequestDto dto,
        CancellationToken cancellationToken = default);
}