using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public sealed record Id : ValueObject
{
    public int Value { get; private set; }

    private Id(int value)
    {
        Value = value;
    }

    public static Result<Id> Create(int value)
    {
        if (value <= 0)
        {
            return Result.Failure<Id>(DomainErrors.Entities.Appointment.Id.InvalidId);
        }

        return new Id(value);
    }

    /// <summary>
    /// This method is used to create an object
    /// from a value retrieved from the database.
    /// It bypasses the validation logic in the Create method,
    /// so it should only be used when you are certain that the
    /// value is valid and has been previously validated.
    /// </summary>
    /// <param name="value"></param>
    public static Id FromDatabase(int value)
    {
        return new Id(value);
    }
}