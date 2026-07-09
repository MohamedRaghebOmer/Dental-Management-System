using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public sealed record DateOfBirth : ValueObject
{
    public const int MinimumAge = 1;
    public const int MaximumAge = 100;

    public DateOnly Value { get; private set; }

    private DateOfBirth(DateOnly value)
    {
        Value = value;
    }

    public static Result<DateOfBirth> Create(DateOnly value)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);

        if (value > today.AddYears(-MinimumAge))
        {
            return Result.Failure<DateOfBirth>
                (DomainErrors.ValueObjects.DateOfBirth.LessThanMinimumAllowedAge);
        }

        if (value < today.AddYears(-MaximumAge))
        {
            return Result.Failure<DateOfBirth>(DomainErrors.ValueObjects.DateOfBirth.OlderThanMaximumAllowedAge);
        }

        return new DateOfBirth(value);
    }

    /// <summary>
    /// This method is used to create an object
    /// from a value retrieved from the database.
    /// It bypasses the validation logic in the Create method,
    /// so it should only be used when you are certain that the
    /// value is valid and has been previously validated.
    /// </summary>
    /// <param name="value"></param>
    public static DateOfBirth FromDatabase(DateOnly value)
    {
        return new DateOfBirth(value);
    }

    public int CalculateAge()
    {
        var today = DateOnly.FromDateTime(DateTime.Now);

        var age = today.Year - Value.Year;

        if (Value > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}