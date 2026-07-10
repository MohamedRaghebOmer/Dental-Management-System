using Dental.Application.DTOs.Supplier;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface ISupplierService
{
    Task<Result<int>> CreateAsync(
        SupplierRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int supplierId,
        SupplierRequestDto dto,
        CancellationToken cancellationToken = default);
}