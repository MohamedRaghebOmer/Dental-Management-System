using Dental.Application.DTOs.Visit;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IVisitService
{
    Task<Result<int>> CreateWalkInVisitAsync(
        WalkInVisitDto walkInVisitDto,
        CancellationToken cancellationToken = default);

    Task<Result<int>> CreatePreAppointmentVisitAsync(
        PreAppointmentVisitDto preAppointmentVisitDto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int visitId,
        UpdateVisitDto updateVisitDto,
        CancellationToken cancellationToken = default);

    Task<Result<VisitResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);


    Task<List<VisitResponseDto>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}