using Dental.Application.DTOs.LabTransaction;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface ILabTransactionService
{
    Task<Result<bool>> ExistsAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<Result<LabTransactionResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<List<LabTransactionResponseDto>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<Result<int>> CreateAsync(LabTransactionRequestDto requestDto);

    Task<Result> UpdateAsync(
        int id,
        LabTransactionRequestDto requestDto,
        CancellationToken cancellationToken = default);
}