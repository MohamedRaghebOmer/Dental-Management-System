using Dental.Application.DTOs.Appointment;
using Dental.Application.DTOs.DentalInfo;
using Dental.Domain.Shared;

namespace Dental.Application.Abstractions.ServicesInterfaces;

public interface IAppointmentService
{
    Task<Result<int>> CreateAsync(AppointmentRequestDto requestDto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int appointmentId,
        AppointmentRequestDto dto,
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

    Task<Result<AppointmentResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);


    Task<Result<IEnumerable<AppointmentResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default);


    Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}