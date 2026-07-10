namespace Dental.Domain.Repositories;

public interface ISupplierRepository
{
    Task<bool> PhoneNumberExistsAsync(
        string phoneNumber, 
        int? excludedId = null,
        CancellationToken cancellationToken = default);
}