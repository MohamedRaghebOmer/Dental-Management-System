using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public sealed record LastName : ValueObject
{
    public const int MaxLength = 50;
    public string Value { get; private set; }

    private LastName(string value)
    {
        Value = value;
    }

    public static Result<LastName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<LastName>(DomainErrors.ValueObjects.LastName.Empty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<LastName>(DomainErrors.ValueObjects.LastName.TooLong);
        }

        return new LastName(value);
    }

    /// <summary>
    /// This method is used to create an object
    /// from a value retrieved from the database.
    /// It bypasses the validation logic in the Create method,
    /// so it should only be used when you are certain that the
    /// value is valid and has been previously validated.
    /// </summary>
    /// <param name="value"></param>
    public static LastName FromDatabase(string value)
    {
        return new LastName(value);
    }

}