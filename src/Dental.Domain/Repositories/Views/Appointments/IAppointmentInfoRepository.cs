using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Appointment;

namespace Dental.Domain.Repositories.Views.Appointments;

public interface IAppointmentInfoRepository
{
    Task<AppointmentInfo?> GetAppointmentInfoAsync(
        Id appointmentId, CancellationToken cancellationToken = default);

    Task<List<AppointmentInfo>> GetAllAppointmentsInfoAsync(
        AppointmentInfo? filterInfo = null,
        CancellationToken cancellationToken = default);

    Task<List<ShortAppointmentInfo>> GetAllShortAppointmentsInfoAsync(
        ShortAppointmentInfo? filterInfo = null,
        CancellationToken cancellationToken = default);
}