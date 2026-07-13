using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dental.Infrastructure.Repositories;

public sealed class VisitRepository
    : Repository<Visit>, 
    IVisitRepository
{
    private readonly DentalDbContext dbContext;

    public VisitRepository(DentalDbContext dbContext)
        : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Visit?> GetVisitByPrescriptionItemIdAsync(
        int prescriptionItemId, 
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Visits
            .Include(v => v.Prescription)
            .ThenInclude(p => p.Items)
            .FirstOrDefaultAsync(
                v => v.Prescription != null &&
                     v.Prescription.Items.Any(i => i.Id == Id.FromDatabase(prescriptionItemId)),
                cancellationToken);
    }

    public Task<bool> PrescriptionExistsAsync(
        int prescriptionId, 
        CancellationToken cancellationToken = default)
    {
        return dbContext.Visits
            .AnyAsync(v => v.PrescriptionId == Id.FromDatabase(prescriptionId), cancellationToken);
    }
}