using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Appointment;

namespace Dental.Domain.Repositories.Views.Appointments;

public interface IAppointmentInfoRepository
{
    Task<AppointmentInfo?> GetAppointmentInfoAsync(
        Id appointmentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrives all the 'AppointmentInfo' except the 'Notes' field, 
    /// which is not needed for the list view.
    /// </summary>
    /// <returns>
    /// A list of 'AppointmentInfo' objects that match the filter criteria.
    /// </returns>
    Task<List<AppointmentInfo>> GetAllAppointmentsInfoAsync(
        AppointmentInfo? filterInfo = null,
        CancellationToken cancellationToken = default);

    Task<List<ShortAppointmentInfo>> GetAllShortAppointmentsInfoAsync(
        ShortAppointmentInfo? filterInfo = null,
        CancellationToken cancellationToken = default);
}