using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public sealed record PhoneNumber : ValueObject
{
    public string Value { get; private set; }
    public const int Length = 11;

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public static Result<PhoneNumber> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<PhoneNumber>(DomainErrors.ValueObjects.PhoneNumber.Empty);
        }

        value = value.Trim();

        if (value.Length != Length)
        {
            return Result.Failure<PhoneNumber>(DomainErrors.ValueObjects.PhoneNumber.Invalid);
        }

        return new PhoneNumber(value);
    }

    /// <summary>
    /// This method is used to create an object
    /// from a value retrieved from the database.
    /// It bypasses the validation logic in the Create method,
    /// so it should only be used when you are certain that the
    /// value is valid and has been previously validated.
    /// </summary>
    /// <param name="value"></param>
    public static PhoneNumber FromDatabase(string value)
    {
        return new PhoneNumber(value);
    }

}