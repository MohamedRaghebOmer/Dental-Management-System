using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class SupplierRepository(DentalDbContext _dbContext)
    : Repository<Supplier>(_dbContext), 
        ISupplierRepository
{
    public Task<bool> PhoneNumberExistsAsync(
        string phoneNumber, 
        int? excludedId = null, 
        CancellationToken cancellationToken = default)
    {
        if (excludedId == null)
        {
            return _dbContext.Suppliers.AnyAsync(
                s => s.PhoneNumber == PhoneNumber.FromDatabase(phoneNumber),
                cancellationToken);
        }

        return _dbContext.Suppliers.AnyAsync(
            s => s.PhoneNumber == PhoneNumber.FromDatabase(phoneNumber) 
            && s.Id != Id.FromDatabase(excludedId.Value),
            cancellationToken);
    }
}