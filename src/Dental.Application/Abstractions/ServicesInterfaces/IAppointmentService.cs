using Dental.Application.DTOs.Appointment;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IAppointmentService
{
    Task<Result<int>> CreateAsync(CreateAppointmentDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int appointmentId,
        UpdateAppointmentDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> CancelAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<Result> CompleteAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<Result<bool>> IsMissed(
        int id,
        CancellationToken cancellationToken = default);
}