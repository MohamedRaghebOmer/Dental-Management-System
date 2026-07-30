using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Infrastructure.Persistence;

namespace Dental.Infrastructure.Repositories;

public sealed class VisitPaymentRepository
    : Repository<VisitPayment>
    , IVisitPaymentRepository
{
    private readonly DentalDbContext _dbContext;

    public VisitPaymentRepository(DentalDbContext dbContext) : base(dbContext)
       => _dbContext = dbContext;
}