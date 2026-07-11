using Dental.Application.DTOs.DentalInfo;
using Dental.Application.DTOs.PrescriptionItem;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IPrescriptionItemService
{
    Task<Result<int>> CreateAsync(
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int id,
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result<PrescriptionItemResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);


    Task<Result<IEnumerable<PrescriptionItemResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}