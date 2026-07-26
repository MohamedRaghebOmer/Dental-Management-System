using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class SupplierRepository
    : Repository<Supplier>,
        ISupplierRepository
{
    private readonly DentalDbContext _dbContext;

    public SupplierRepository(DentalDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> PhoneNumberExistsAsync(
        PhoneNumber phoneNumber,
        Id? excludedId = null,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Suppliers.AnyAsync(
            s => s.PhoneNumber == phoneNumber && s.Id != excludedId, cancellationToken);
    }
}