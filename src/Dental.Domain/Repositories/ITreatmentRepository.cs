namespace Dental.Domain.Repositories;

public interface ITreatmentRepository
{
    Task<bool> ExistsByNameAsync(
        string name,
        int? excludedId = null,
        CancellationToken  cancellationToken = default);
}