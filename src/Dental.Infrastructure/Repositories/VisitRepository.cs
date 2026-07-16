using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class VisitRepository
    : Repository<Visit>, IVisitRepository
{
    private readonly DentalDbContext _dbContext;

    public VisitRepository(DentalDbContext dbContext) : base(dbContext)
        => _dbContext = dbContext;


    public Task<Visit?> GetByPrescriptionIdAsync(
        Id id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Visit> query = _dbContext.Visits;

        if (asNoTracking)
            query = query.AsNoTracking();

        return query
            .FirstOrDefaultAsync(
                v => v.Prescription != null &&
                     v.Prescription.Id == id,
                cancellationToken);
    }

    public Task<Visit?> GetByPrescriptionItemIdAsync(
        Id id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Visit> query = _dbContext.Visits;
        
        if(asNoTracking) 
            query = query.AsNoTracking();

        return query
                .FirstOrDefaultAsync(
                    v => v.Prescription != null &&
                         v.Prescription.Items.Any(i => i.Id == id),
                    cancellationToken);
    }

    public Task<Visit?> GetByTreatmentIdAsync(
        Id id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Visit> query = _dbContext.Visits;

        if (asNoTracking)
            query = query.AsNoTracking();

        return query
            .FirstOrDefaultAsync(v => v.VisitTreatments.Any(vt => vt.Id == id),
            cancellationToken);
    }


    public Task<bool> PrescriptionExistsAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Prescriptions
            .AnyAsync(p => p.Id == id, cancellationToken);
    }

    public Task<bool> PrescriptionItemExistsAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.PrescriptionsItems
            .AnyAsync(pi => pi.Id == id, cancellationToken);
    }

    public Task<bool> TreatmentExistsAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.VisitTreatments
            .AnyAsync(vt => vt.Id == id, cancellationToken);
    }



    public Task<bool> ExistsByAppointmentIdAsync(
        Id appointmentId,
        Id? excludedId,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Visits
            .AnyAsync(v => v.AppointmentId == appointmentId && v.Id != excludedId
            , cancellationToken);
    }

    public Task DeleteAllVisitTreatmentsBelongToVisitAsync(
        Id visitId,
        CancellationToken cancellationToken = default)
    {
        _dbContext.ChangeTracker.Clear();
        
        return _dbContext.VisitTreatments
            .Where(vt => vt.VisitId == visitId)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public Task<Dictionary<int, Visit>> GetByIdsAsync(
        IEnumerable<Id> ids,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Visits
            .Where(v => ids.Contains(v.Id))
            .ToDictionaryAsync(
                v => v.Id.Value,
                cancellationToken);
    }
}