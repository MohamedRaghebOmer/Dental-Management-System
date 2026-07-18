using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Repositories;

public interface IAppointmentRepository
    : IRepository<Appointment>
{
    Task<bool> ExistsByScheduleVisitDateTimeAsync(
        DateTime date,
        Id? excludeId = null,
        CancellationToken cancellationToken = default);
}