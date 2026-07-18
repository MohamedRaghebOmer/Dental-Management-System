using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Repositories;

public interface ISupplierRepository
    : IRepository<Supplier>
{
    Task<bool> PhoneNumberExistsAsync(
        PhoneNumber phoneNumber,
        Id? excludedId = null,
        CancellationToken cancellationToken = default);
}