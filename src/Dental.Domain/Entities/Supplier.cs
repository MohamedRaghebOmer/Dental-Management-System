using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Supplier : Entity
{
    private Supplier() { } // EF Core
    private Supplier(
        string name,
        PhoneNumber? phoneNumber,
        string? address,
        string? description)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        Description = description;
    }

    public static class Constants
    {
        public const int NameMaxLength = 50;
        public const int PhoneNumberMaxLength = PhoneNumber.Length;
        public const int AddressMaxLength = 100;
        public const int DescriptionMaxLength = 200;
    }


    public string Name { get; private set; } = string.Empty;
    public PhoneNumber? PhoneNumber { get; private set; } = default!;
    public string? Address { get; private set; } = null;
    public string? Description { get; private set; } = null;

    public ICollection<Material> Materials { get; private set; } = [];

    public static Result<Supplier> Create(
        string name,
        PhoneNumber? phoneNumber,
        string? address,
        string? description)
    {
        var validationResult = Validate(name, phoneNumber, address, description);

        if (validationResult.IsFailure)
            return Result.Failure<Supplier>(validationResult.Error);

        return new Supplier(name.Trim(), phoneNumber, address?.Trim(), description?.Trim());
    }

    public Result Update(
        string name,
        PhoneNumber? phoneNumber,
        string? address,
        string? description)
    {
        var validationResult = Validate(name, phoneNumber, address, description);

        if (validationResult.IsFailure)
            return Result.Failure(validationResult.Error);

        Name = name.Trim();
        PhoneNumber = phoneNumber;
        Address = address?.Trim();
        Description = description?.Trim();

        return Result.Success();
    }

    private static Result Validate(
        string name,
        PhoneNumber? phoneNumber,
        string? address,
        string? description)
    {
        if (name?.Trim().Length > Constants.NameMaxLength)
            return Result.Failure(DomainErrors.Entities.Supplier.Name.TooLong);

        if (address?.Trim().Length > Constants.AddressMaxLength)
            return Result.Failure(DomainErrors.Entities.Supplier.Address.TooLong);

        if (description?.Trim().Length > Constants.DescriptionMaxLength)
            return Result.Failure(DomainErrors.Entities.Supplier.Description.TooLong);

        return Result.Success();
    }
}