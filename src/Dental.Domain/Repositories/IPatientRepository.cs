using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;

namespace Dental.Infrastructure.Repositories;

public interface IPatientRepository
    : IRepository<Patient>
{
    Task<Patient?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<bool> ExistsByNameAsync(
        string name,
        Id? excludedId = null,
        CancellationToken cancellationToken = default);
}