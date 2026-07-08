using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public record Money : ValueObject
{
    public Decimal Value { get; private set; } = 0m;

    private Money(decimal value)
    {
        Value = value;
    }

    public static Result<Money> Create(decimal value)
    {
        if (value < 0)
        {
            return Result.Failure<Money>(DomainErrors.Services.Money.NonPositiveValue);
        }

        return new Money(value);
    }

    /// <summary>
    /// This method is used to create an object
    /// from a value retrieved from the database.
    /// It bypasses the validation logic in the Create method,
    /// so it should only be used when you are certain that the
    /// value is valid and has been previously validated.
    /// </summary>
    /// <param name="value"></param>
    public static Money FromDatabase(decimal value)
    {
        return new Money(value);
    }
}