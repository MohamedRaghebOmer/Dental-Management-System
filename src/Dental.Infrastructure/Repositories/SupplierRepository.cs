using Dental.Domain.Entities;
using Dental.Domain.Repositories;
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
        return _dbContext.Suppliers.AnyAsync(
            s => s.PhoneNumber != null && s.PhoneNumber.Value == phoneNumber && s.Id.Value != excludedId,
            cancellationToken);
    }
}