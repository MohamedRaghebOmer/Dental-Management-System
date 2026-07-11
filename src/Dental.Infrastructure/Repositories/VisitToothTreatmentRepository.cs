using Dental.Domain.Entities;
using Dental.Domain.Repositories;
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

    public async Task<bool> ExistsByToothNumberAndServiceIdAndVisitId(
        byte toothNumber,
        int serviceId,
        int visitId,
        int? excludedId = null,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.VisitToothTreatments
            .AnyAsync(vtt => vtt.ToothNumber.Value == toothNumber
                             && vtt.TreatmentId.Value == serviceId
                             && vtt.VisitId.Value == visitId
                             && vtt.Id.Value != excludedId,
                cancellationToken);
    }
}