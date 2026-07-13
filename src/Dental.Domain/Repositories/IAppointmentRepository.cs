using Dental.Domain.Entities;

namespace Dental.Domain.Repositories;

public interface IAppointmentRepository
    :IRepository<Appointment>
{
    Task<bool> ExistsByDateAsync(
        DateTime date,
        int? excludeId = null,
        CancellationToken cancellationToken = default);
}