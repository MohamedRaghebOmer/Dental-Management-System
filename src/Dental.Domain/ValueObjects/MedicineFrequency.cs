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

    /// <summary>
    /// This method is used to create an object
    /// from a value retrieved from the database.
    /// It bypasses the validation logic in the Create method,
    /// so it should only be used when you are certain that the
    /// value is valid and has been previously validated.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="period"></param>
    public static MedicineFrequency FromDatabase(int value, byte period)
    {
        return new MedicineFrequency(value, (MedicinePeriodFrequency)period);
    }
}