using Dental.Domain.Shared;
using Dental.Domain.Views;

namespace Dental.Application.ViewsStuff.Interfaces;

public interface IAppointmentInfoService
{
    Task<Result<AppointmentInfo?>> GetAppointmentInfoAsync(
        int appointmentId, CancellationToken cancellationToken = default);

    Task<List<AppointmentInfo>> GetAllAppointmentsInfoAsync(
        AppointmentInfo? filterInfo,
        CancellationToken cancellationToken = default);
}