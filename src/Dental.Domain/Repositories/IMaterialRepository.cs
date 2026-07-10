namespace Dental.Domain.Repositories;

public interface IMaterialRepository
{
    Task<bool> ExistsByNameAsync(
        string name, 
        int? excludeId = null, 
        CancellationToken cancellationToken = default);
}