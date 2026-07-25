using Dental.Domain.Repositories.Views.Visits;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Visit;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories.Views.Visit;

public sealed class VisitTreatmentsViewRepository(DentalDbContext dbContext)
    : IVisitToothTreatmentsViewRepository
{
    public Task<List<VisitTreatmentsView>> GetAsync(
        Id visitId,
        CancellationToken cancellationToken = default)
    {
        var query = dbContext.VisitTreatments
            .Where(vtt => vtt.VisitId == visitId)
            .Include(vtt => vtt.Treatment)
            .Select(
               vtt => new VisitTreatmentsView
               {
                   ToothNumber = vtt.ToothNumber.Value,
                   Name = vtt.Treatment.Name,
                   Price = vtt.Treatment.Price.Value,
                   Notes = vtt.Notes
               })
            .AsNoTracking();

        return query.ToListAsync();
    }
}
