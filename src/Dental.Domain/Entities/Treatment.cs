using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Treatment : Entity
{
    public static class Constants
    {
        public const int DescriptionMaxLength = 500;
        public const int NameMaxLength = 100;
    }

    private Treatment(
        string name,
        Money price,
        string? description = null)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    private Treatment(
        Id id,
        string name,
        Money price,
        string? description = null)
    {
        base.Id = id;
        Name = name;
        Price = price;
        Description = description;
    }

    private Treatment() { } // EF Core


    public string Name { get; private set; } = string.Empty;

    public Money Price { get; private set; } = default!;

    public string? Description { get; private set; } = null;
    public ICollection<VisitToothTreatment> VisitToothTreatments { get; private set; } = [];

    public static Result<Treatment> Create(
        string name,
        Money price,
        string? description = null)
    {
        if (!string.IsNullOrWhiteSpace(description)
            && description.Length > Constants.DescriptionMaxLength)
        {
            return Result.Failure<Treatment>(DomainErrors.Entities.Treatment.Description.TooLong);
        }

        return new Treatment(name, price, description?.Trim());
    }

    public Result Update(
        string name,
        Money price,
        string? description = null)
    {
        if (!string.IsNullOrWhiteSpace(description)
            && description.Length > Constants.DescriptionMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Treatment.Description.TooLong);
        }

        Name = name;
        Price = price;
        Description = description?.Trim();

        return Result.Success();
    }

    public static Treatment[] InitialData()
    {
        return
        [
            new Treatment(Id.FromDatabase(1), "حشو عصب", Money.FromDatabase(100.00m)),
            new Treatment(Id.FromDatabase(2), "حشو ليزر", Money.FromDatabase(100.00m)),
            new Treatment(Id.FromDatabase(3), "تركيبات", Money.FromDatabase(100.00m)),
            new Treatment(Id.FromDatabase(4), "خلع", Money.FromDatabase(100.00m)),
            new Treatment(Id.FromDatabase(5), "زراعه", Money.FromDatabase(100.00m)),
            new Treatment(Id.FromDatabase(6), "تقويم", Money.FromDatabase(100.00m)),
            new Treatment(Id.FromDatabase(7), "تنظيف جير", Money.FromDatabase(100.00m)),
            new Treatment(Id.FromDatabase(8), "تلميع", Money.FromDatabase(100.00m)),
            new Treatment(Id.FromDatabase(9), "تبيض", Money.FromDatabase(100.00m))
        ];
    }
}