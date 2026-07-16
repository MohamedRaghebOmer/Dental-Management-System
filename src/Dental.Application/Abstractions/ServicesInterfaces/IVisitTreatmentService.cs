using Dental.Application.DTOs.VisitToothNumber;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitTreatmentService
{
    Task<Result<int>> CreateAsync(
        VisitTreatmentRequestDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> CreateManyAsync(
        VisitTreatmentRequestDto[] dtos,
        CancellationToken cancellationToken = default);

    Task<Result> SetAllVisitTreatmentsAsync(
        int visitId,
        VisitTreatmentRequestDto[] dtos,
        CancellationToken cancellationToken = default);
}