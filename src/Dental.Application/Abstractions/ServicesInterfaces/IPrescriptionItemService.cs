using Dental.Application.DTOs.PrescriptionItem;
using Dental.Domain.Entities;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IPrescriptionItemService
{
    Task<Result<PrescriptionItem>> CreateAsync(
        int visitId,
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int id,
        PrescriptionItemRequestDto dto,
        CancellationToken cancellationToken = default);
}