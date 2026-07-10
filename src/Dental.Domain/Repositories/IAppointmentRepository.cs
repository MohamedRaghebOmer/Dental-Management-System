namespace Dental.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<bool> ExistsByDateAsync(
        DateTime date,
        int? excludeId = null,
        CancellationToken cancellationToken = default);
}