using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class PatientRepository
    : Repository<Patient>
    , IPatientRepository
{
    private readonly DentalDbContext _dbContext;

    public PatientRepository(DentalDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Patient?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return _dbContext.Patients
            .FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
    }

    public Task<bool> ExistsByNameAsync(
        string name,
        Id? excludedId,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Patients
            .AnyAsync(p => p.Name == name && p.Id != excludedId, cancellationToken);
    }

    public async Task<bool> CanDeleteAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        var canDeleteFromVisits = !await _dbContext.Visits
            .AnyAsync(v => v.PatientId == id, cancellationToken);

        var canDeleteFromAppointments = !await _dbContext.Appointments
            .AnyAsync(a => a.PatientId == id, cancellationToken);

        return canDeleteFromVisits && canDeleteFromAppointments;
    }
}
