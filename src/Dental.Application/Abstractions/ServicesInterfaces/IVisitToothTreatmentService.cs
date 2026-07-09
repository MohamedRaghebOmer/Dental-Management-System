using Dental.Application.DTOs.VisitToothNumber;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitToothTreatmentService
{
    Task<Result<int>> CreateAsync(
        VisitToothTreatmentRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int id,
        VisitToothTreatmentRequestDto dto,
        CancellationToken cancellationToken = default);
}