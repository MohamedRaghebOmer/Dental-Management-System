using Dental.Domain.Repositories.Views;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dental.Infrastructure.Repositories.Views;

public sealed class VisitToothTreatmentsViewRepository(DentalDbContext dbContext) : IVisitToothTreatmentsViewRepository
{
    public async Task<List<VisitTreatmentsView>> GetAsync(
        int visitId, 
        CancellationToken cancellationToken = default)
    {
        var query = dbContext.VisitTreatments
            .Where(vtt => vtt.VisitId == Id.FromDatabase(visitId))
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

        Debug.WriteLine(query.ToQueryString());
        return await query.ToListAsync();
    }
}
