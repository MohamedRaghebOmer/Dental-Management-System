using Dental.Domain.ValueObjects;
using Dental.Domain.Views;

namespace Dental.Domain.Repositories.Views;

public interface IAppointmentInfoRepository
{
    Task<AppointmentInfo?> GetAppointmentInfoAsync(
        Id appointmentId, CancellationToken cancellationToken = default);

    Task<List<AppointmentInfo>> GetAllAppointmentsInfoAsync(
        AppointmentInfo? filterInfo = null,
        CancellationToken cancellationToken = default);
}