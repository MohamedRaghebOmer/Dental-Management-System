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
                Result.Failure<ToothNumber>(DomainErrors.VisitToothTreatment.ToothNumber.OutOfRange);
        }

        return new ToothNumber(value);
    }

    public static ToothNumber FromDatabase(byte value)
    {
        return new ToothNumber(value);
    }
}