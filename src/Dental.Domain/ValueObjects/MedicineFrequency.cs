using Dental.Domain.Enums;
using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public sealed record MedicineFrequency : ValueObject
{
    public int Value { get; }
    public MedicinePeriodFrequency Period { get; }

    private MedicineFrequency(int value, MedicinePeriodFrequency period)
    {
        Value = value;
        Period = period;
    }

    public static Result<MedicineFrequency> Create(int value, MedicinePeriodFrequency period)
    {
        if (value <= 0)
        {
            return Result.Failure<MedicineFrequency>(DomainErrors.ValueObjects.MedicineFrequency.NegativeValue);
        }

        return new MedicineFrequency(value, period);
    }
}