using Dental.Domain.Entities;

namespace Dental.Domain.Repositories;

public interface ISupplierRepository
    : IRepository<Supplier>
{
    Task<bool> PhoneNumberExistsAsync(
        string phoneNumber, 
        int? excludedId = null,
        CancellationToken cancellationToken = default);
}