using Dental.Application.DTOs.VisitPayment;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitPaymentService
{
    Task<Result> UpdateManyAsync(
        List<UpdateVisitPaymentDto> updateDtos,
        CancellationToken cancellationToken = default);

    Task<Result> CreateMenyAsync(
        List<CreateVisitPaymentDto> addDtos,
        CancellationToken cancellationToken = default);

    Task<Result> DeleteManyAsync(IEnumerable<int> paymentIds);
}