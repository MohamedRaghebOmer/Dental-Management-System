using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class TreatmentRepository
    : Repository<Treatment>,
        ITreatmentRepository
{
    private readonly DentalDbContext _dbContext;

    public TreatmentRepository(DentalDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> ExistsByNameAsync(
        string name,
        Id? excludedId = null,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Treatments.AnyAsync(
            t => t.Name == name && t.Id != excludedId, cancellationToken);
    }

    public Task<Money?> GetPriceByIdAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Treatments
            .Where(t => t.Id == id)
            .Select(t => t.Price)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<List<Treatment>> GetAllAsync(
        string? filterTreatmentName = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Treatment> query = _dbContext.Treatments;

        if (!string.IsNullOrWhiteSpace(filterTreatmentName))
            query = query.Where(t => t.Name.Contains(filterTreatmentName));

        return query.ToListAsync(cancellationToken);
    }

    public Task<Dictionary<int, decimal>> GetPricesByIdsAsync(
        IEnumerable<Id> ids,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Treatments
            .AsNoTracking()
            .Where(t => ids.Contains(t.Id))
            .ToDictionaryAsync(
                t => t.Id.Value,
                t => t.Price.Value,
                cancellationToken);
    }

    public Task<Dictionary<int, decimal>> GetAllIdsAndPricesAsync(
    CancellationToken cancellationToken = default)
    {
        return _dbContext.Treatments
            .AsNoTracking()
            .ToDictionaryAsync(
                t => t.Id.Value,
                t => t.Price.Value,
                cancellationToken);
    }

    public Task<bool> CanDeleteAsync(
        Id idResultValue,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.VisitTreatments
            .AsNoTracking()
            .AnyAsync(vt => vt.TreatmentId == idResultValue, cancellationToken)
            .ContinueWith(
                static t => !t.Result,
                cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
    }
}