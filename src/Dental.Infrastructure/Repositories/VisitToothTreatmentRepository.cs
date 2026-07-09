using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class VisitToothTreatmentRepository(DentalDbContext _dbContext)
    : Repository<VisitToothTreatment>(_dbContext),
        IVisitToothTreatmentRepository
{
    public async Task<decimal> GetTotalCostAsync(
        int visitId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.VisitToothTreatments
            .Where(vtt => vtt.VisitId.Value == visitId)
            .SumAsync(vtt => vtt.Price.Value, cancellationToken);
    }

    public async Task<bool> AreServiceIdAndVisitIdExists(
        int serviceId,
        int visitId)
    {
        return await _dbContext.VisitToothTreatments
            .AnyAsync(vtt => vtt.ServiceId.Value == serviceId 
                             && vtt.VisitId.Value == visitId);
    }
}