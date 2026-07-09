using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public sealed record ToothNumber : ValueObject
{
    public byte Value { get; }

    private ToothNumber(byte value)
    {
        Value = value;
    }

    public static Result<ToothNumber> Create(byte value)
    {
        if (value is 0 or > 32)
        {
            return
                Result.Failure<ToothNumber>(DomainErrors.ValueObjects.ToothNumber.OutOfRange);
        }

        return new ToothNumber(value);
    }

    /// <summary>
    /// This method is used to create an object
    /// from a value retrieved from the database.
    /// It bypasses the validation logic in the Create method,
    /// so it should only be used when you are certain that the
    /// value is valid and has been previously validated.
    /// </summary>
    /// <param name="value"></param>
    public static ToothNumber FromDatabase(byte value)
    {
        return new ToothNumber(value);
    }
}