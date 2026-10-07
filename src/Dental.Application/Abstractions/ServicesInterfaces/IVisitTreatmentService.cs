using Dental.Application.DTOs.VisitTreatments;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitTreatmentService
{
    Task<Result<int>> CreateAsync(
        CreateVisitTreatmentDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> CreateManyAsync(
        CreateVisitTreatmentDto[] dtos,
        CancellationToken cancellationToken = default);

    Task<Result> SyncVisitTreatmentsAsync(
        CreateVisitTreatmentDto[] newVisitTreatments,
        UpdateVisitTreatmentDto[] updatedVisitTreatments,
        HashSet<int> deletedVisitTreatmens,
        CancellationToken cancellationToken = default);
}