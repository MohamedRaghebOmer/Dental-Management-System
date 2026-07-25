using Dental.Domain.Shared;
using Dental.Domain.Views.Appointment;

namespace Dental.Application.ViewsStuff.Interfaces.Appointments;

public interface IAppointmentInfoService
{
    Task<Result<AppointmentInfo?>> GetAppointmentInfoAsync(
        int appointmentId, CancellationToken cancellationToken = default);

    Task<List<AppointmentInfo>> GetAllAppointmentsInfoAsync(
        AppointmentInfo? filterInfo,
        CancellationToken cancellationToken = default);

    Task<List<ShortAppointmentInfo>> GetAllShortAppointmentsInfoAsync(
        ShortAppointmentInfo? filterInfo = null,
        CancellationToken cancellationToken = default);
}