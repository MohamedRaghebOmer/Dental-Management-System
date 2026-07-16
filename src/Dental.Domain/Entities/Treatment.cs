using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using System.Net.Http.Headers;

namespace Dental.Domain.Entities;

public sealed class Treatment : Entity
{
    public static class Constants
    {
        public const int DescriptionMaxLength = 500;
        public const int NameMaxLength = 100;
    }

    private Treatment() { } // EF Core

    private Treatment(
        string name,
        Money price,
        string? description = null)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    // To initialize the initial data from
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


    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; } = default!;
    public string? Description { get; private set; } = null;

    public ICollection<VisitTreatment> VisitTreatments { get; private set; } = [];



    public static Result<Treatment> Create(
        string name,
        Money price,
        string? description = null)
    {
        name = name.Trim();
        description = description?.Trim();

        var validateResult = Validate(name, description);
        if (validateResult.IsFailure)
        {
            return Result.Failure<Treatment>(validateResult.Error);
        }

        return new Treatment(name, price, description);
    }

    public Result Update(
        string name,
        Money price,
        string? description = null)
    {
        name = name.Trim();
        description = description?.Trim();

        var validateResult = Validate(name, description);
        if (validateResult.IsFailure)
        {
            return Result.Failure<Treatment>(validateResult.Error);
        }

        Name = name;
        Price = price;
        Description = description;

        return Result.Success();
    }

    private static Result Validate(string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Treatment>(DomainErrors.Entities.Treatment.Name.Empty);
        }

        if (name.Length > Constants.NameMaxLength)
        {
            return Result.Failure<Treatment>(DomainErrors.Entities.Treatment.Name.TooLong);
        }

        if (!string.IsNullOrWhiteSpace(description)
            && description.Length > Constants.DescriptionMaxLength)
        {
            return Result.Failure<Treatment>(DomainErrors.Entities.Treatment.Description.TooLong);
        }

        return Result.Success();
    }


    public static Treatment[] InitialData()
    {
        return
        [
            new Treatment(Id.FromDatabase(1), "حشو عصب", Money.FromDatabase(260.00m)),
            new Treatment(Id.FromDatabase(2), "حشو ليزر", Money.FromDatabase(450.00m)),
            new Treatment(Id.FromDatabase(3), "تركيبات", Money.FromDatabase(130.00m)),
            new Treatment(Id.FromDatabase(4), "خلع", Money.FromDatabase(120.00m)),
            new Treatment(Id.FromDatabase(5), "زراعه", Money.FromDatabase(730.00m)),
            new Treatment(Id.FromDatabase(6), "تقويم", Money.FromDatabase(1530.00m)),
            new Treatment(Id.FromDatabase(7), "تنظيف جير", Money.FromDatabase(204.00m)),
            new Treatment(Id.FromDatabase(8), "تلميع", Money.FromDatabase(143.00m)),
            new Treatment(Id.FromDatabase(9), "تبيض", Money.FromDatabase(138.00m))
        ];
    }
}