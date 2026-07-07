using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class ServiceRepository(DentalDbContext _dbContext) : IServiceRepository
{
    public async Task AddServiceAsync(
        Service service,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Services.AddAsync(service, cancellationToken);
    }

    public async Task<Service?> GetServiceByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Services.FindAsync(
            [id],
            cancellationToken);
    }

    public async Task DeleteServiceAsync(int id, CancellationToken cancellationToken = default)
    {
        await _dbContext.Services
            .Where(s => s.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<IEnumerable<Service>> ListServicesAsync(
        CancellationToken cancellationToken)
    {
        return await _dbContext.Services.ToListAsync(cancellationToken);
    }
}