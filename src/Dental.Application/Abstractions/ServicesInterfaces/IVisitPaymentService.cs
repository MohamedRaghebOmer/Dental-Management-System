using Dental.Application.DTOs.VisitPayment;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitPaymentService
{
    Task<Result<VisitPaymentResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<List<VisitPaymentResponseDto>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}