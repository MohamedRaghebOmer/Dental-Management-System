using Dental.Domain.Entities;

namespace Dental.Domain.Interfaces.Repositories;

public interface IServiceRepository
{
    Task AddServiceAsync(
        Service service,
        CancellationToken cancellationToken = default);

    Task<Service?> GetServiceByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task DeleteServiceAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<Service>> ListServicesAsync(
        CancellationToken cancellationToken);
}