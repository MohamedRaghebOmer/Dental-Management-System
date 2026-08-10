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
        IQueryable<VisitTreatmentsView> query = dbContext.VisitTreatments
            .AsNoTracking()
            .Where(vtt => vtt.VisitId == visitId)
            .Select(
               vtt => new VisitTreatmentsView
               {
                   ToothNumber = vtt.ToothNumber == null? null : vtt.ToothNumber.Value,
                   Name = vtt.Treatment.Name,
                   Price = vtt.Treatment.Price.Value,
                   Count = vtt.Count,
                   TotalPrice = vtt.TreatmentPrice.Value * vtt.Count,
                   Notes = vtt.Notes
               });

        return query.ToListAsync(cancellationToken);
    }
}
