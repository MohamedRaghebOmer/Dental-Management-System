using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Infrastructure.Persistence;

namespace Dental.Infrastructure.Repositories;

public sealed class LabTransactionRepository
    : Repository<LabTransaction>
    , ILabTransactionRepository
{
    private readonly DentalDbContext _dbContext;

    public LabTransactionRepository(DentalDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}