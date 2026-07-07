using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public record Money : ValueObject
{
    public Decimal Value { get; } = 0m;

    public Money(decimal value)
    {
        Value = value;
    }

    public static Result<Money> Create(decimal value)
    {
        if (value <= 0)
        {
            return Result.Failure<Money>(DomainErrors.Services.Money.NonPositiveValue);
        }

        return new Money(value);
    }

    internal static Money FromDatabase(decimal value)
    {
        return new Money(value);
    }
}